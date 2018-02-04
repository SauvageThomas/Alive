using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    [SerializeField]
    private Player player;
    public Player Player {
        get { return player; }
        private set { }
    }

    
    private List<Creature> creatures = new List<Creature>();


    [SerializeField]
    private GameObject creaturePrefab;
    public GameObject CreaturePrefab {
        get { return creaturePrefab; }
        private set { }
    }

    private MapScene map;

    private string firstScene = "Demo";

    protected GameManager() { }



    // Use this for initialization
    void Awake() {

        Debug.Log("Awaking the Manager");

        this.LoadScene();
        this.player.SetActive(true);
        

    }

    private void LoadScene() {

        Scene scene = SceneManager.GetActiveScene();

        this.map = ScriptableObject.CreateInstance(typeof(MapScene)) as MapScene;

        if (this.map.Load(Path.Combine("Scenes", scene.name))) {
            Debug.Log(Path.Combine("data/Scenes", scene.name) +" exists");
            this.LoadPlayer();
            this.LoadCreatures();

        }
        else {
            Debug.Log(Path.Combine("data/Scenes", scene.name) + " does not exist");
        }
    }

    private void LoadCreatures() {
        this.creatures = new List<Creature>(); //Erase the creatures that have registered because we load them from disk

        foreach (KeyValuePair<Pair<float, float>, LivingThingData> creaturePosition in this.map.CreaturesPosition) {
            GameObject gameObject = null;

            if (creaturePosition.Value.type == typeof(Creature)) {
                gameObject = Instantiate(this.creaturePrefab);
            }

            Creature creature = gameObject.GetComponent<Creature>();
            creature.Load(creaturePosition.Key.first, creaturePosition.Key.second, creaturePosition.Value.id);

            this.creatures.Add(creature);
        }

        /*foreach(Creature creature in this.creatures) {
            creature.Load(Toolbox.Instance.getID());
        }*/
    }

    void FixedUpdate() {
        foreach (Creature creature in this.creatures) {
            Debug.Log("is the creature visible ?");
            if (creature.IsVisible()) {
                creature.SetActive(true);
            }
        }
    }

    private void LoadPlayer() {
        this.player.Load(this.map.PlayerX, this.map.PlayerY, 0);
        
    }

    //All creature call it to register to the GameManager
    public void Register(Creature creature) {
        this.creatures.Add(creature);
        Debug.Log("registering !!!!!!");
    }

    void OnApplicationQuit() {
        this.map.PlayerX = player.gameObject.transform.position.x;
        this.map.PlayerY = player.gameObject.transform.position.y;

        foreach (Creature creature in this.creatures) {
            this.map.AddCreaturePosition(creature.transform.position.x, creature.transform.position.y, creature.GetID(), creature.GetType()); 
        }

        this.map.Save(Path.Combine("Scenes", SceneManager.GetActiveScene().name));
    }
}
