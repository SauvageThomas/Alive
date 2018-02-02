using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : Singleton<GameManager> {

    [SerializeField]
    private Player player;
    public Player Player {
        get { return player; }
        private set { }
    }

    [SerializeField]
    private List<Creature> creatures;
    public List<Creature> Creatures {
        get { return creatures; }
        private set { }
    }

    protected GameManager() { }



    // Use this for initialization
    void Awake() {
        this.LoadPlayer();
    }

    // Update is called once per frame
    void Update() {

    }

    private void LoadPlayer() {
        this.player.Load();
    }
}
