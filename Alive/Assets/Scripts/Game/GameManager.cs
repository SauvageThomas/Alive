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

    public object SceneChanger { get; private set; }

    private MapScene map;

    private string firstScene = "Demo";
    private bool diskLoading = false;

    protected GameManager() { }

    private Route currentRoute;
    [SerializeField]
    private Camera mainCamera;

    // Use this for initialization
    void Awake() {

        Debug.Log("Awaking the Manager");

        this.LoadScene();
        this.player.SetActive(true);

        //SceneManager.activeSceneChanged += SceneChanged;


    }

    public void NavigateTo(Route route) {
        this.currentRoute = route;

        Action postLoad = () => {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Respawn")) {
                if (go.name.Equals("spawn" + this.currentRoute.spawn)) {
                    this.player.Move(go.transform);

                }
                Debug.Log(go.name);
                Debug.Log("spawn" + this.currentRoute.spawn);
            }
        };

        StartCoroutine(ChangeScene(route, postLoad));

        //SceneManager.LoadScene(route.scene);

    }

    public IEnumerator ChangeScene(Route route, Action action) {

        //TODO: Afficher la description
        bool loaded = false;
        bool unloaded = false;

        if (!loaded) {
            Debug.Log("FIRST !!!!");
            loaded = true;
            yield return SceneManager.LoadSceneAsync(route.scene, LoadSceneMode.Additive);
        }

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(route.scene));

        action();

        if (!unloaded) {
            unloaded = true;
            Debug.Log("SECOND !!!!");
            yield return new WaitForEndOfFrame();
            SceneManager.UnloadSceneAsync(route.spawn);
        }

        NavigationManager.Instance.Navigate = true;

    }

    private void LoadScene() {

        Scene scene = SceneManager.GetActiveScene();

        this.map = ScriptableObject.CreateInstance(typeof(MapScene)) as MapScene;

        if (this.map.Load(Path.Combine("Scenes", scene.name))) {
            this.diskLoading = true;
            Debug.Log(Path.Combine("data/Scenes", scene.name) + " exists");
            this.LoadPlayer();
            this.LoadCreatures();

        }
        else {
            this.AssignID();
            Debug.Log(Path.Combine("data/Scenes", scene.name) + " does not exist");
        }
    }

    private void AssignID() {
        foreach (Creature creature in this.creatures) {
            creature.SetID(Toolbox.Instance.getID());
        }
    }

    private void LoadCreatures() {
        foreach (Creature creature in this.creatures) {
            creature.Destroy();
        }
        this.creatures.Clear(); //Erase the creatures that have registered because we load them from disk

        Debug.Log("At init there is " + creatures.Count + " creatures");

        foreach (KeyValuePair<Pair<float, float>, LivingThingData> creaturePosition in this.map.CreaturesPosition) {
            GameObject gameObject = null;

            if (creaturePosition.Value.type == typeof(Creature)) {
                gameObject = Instantiate(this.creaturePrefab);
            }

            Creature creature = gameObject.GetComponent<Creature>();
            creature.Load(creaturePosition.Key.first, creaturePosition.Key.second, creaturePosition.Value.id);

            this.creatures.Add(creature);
            Debug.Log("Adding new creature : " + creaturePosition.Value.id);
        }

        Debug.Log("There is " + creatures.Count + " creatures");

        /*foreach(Creature creature in this.creatures) {
            creature.Load(Toolbox.Instance.getID());
        }*/
    }

    void FixedUpdate() {

    }

    private void LoadPlayer() {
        this.player.Load(this.map.PlayerX, this.map.PlayerY, 0);

    }

    //All creature call it to register to the GameManager
    public void Register(Creature creature) {
        if (!this.diskLoading) {
            this.creatures.Add(creature);
        }
    }

    void OnApplicationQuit() {
        //Reset the map and add the new Creatures
        this.map = ScriptableObject.CreateInstance(typeof(MapScene)) as MapScene;

        this.map.PlayerX = player.gameObject.transform.position.x;
        this.map.PlayerY = player.gameObject.transform.position.y;
        Debug.Log("Saving the scene ...");
        foreach (Creature creature in this.creatures) {
            Debug.Log("ID : " + creature.GetID());
            this.map.AddCreaturePosition(creature.transform.position.x, creature.transform.position.y, creature.GetID(), creature.GetType());
        }

        this.map.Save(Path.Combine("Scenes", SceneManager.GetActiveScene().name));
    }
}
