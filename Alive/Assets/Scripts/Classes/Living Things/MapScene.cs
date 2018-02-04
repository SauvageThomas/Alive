using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;


[System.Serializable]
public class LivingThingData {

    public long id;
    public Type type;

    public LivingThingData(long id, Type type) {
        this.type = type;
        this.id = id;
    }
}


[System.Serializable]
public class SceneData {

    public Pair<float, float> playerPosition;
    public Dictionary<Pair<float, float>, LivingThingData> creaturesPosition;

    public SceneData(Pair<float, float> playerPosition, Dictionary<Pair<float, float>, LivingThingData> creaturesPosition) {
        this.playerPosition = playerPosition;
        this.creaturesPosition = creaturesPosition;
    }
}

public class MapScene : DataManager<SceneData> {

    private Pair<float, float> playerPosition;
    public float PlayerX {
        get { return playerPosition.first; }
        set { playerPosition.first = value; }
    }
    public float PlayerY {
        get { return playerPosition.second; }
        set { playerPosition.second = value; }
    }

    private Dictionary<Pair<float, float>, LivingThingData> creaturesPosition;
    public Dictionary<Pair<float, float>, LivingThingData> CreaturesPosition {
        get { return creaturesPosition; }
        set { }
    }

    protected override SceneData Data {
        get { return new SceneData(playerPosition, creaturesPosition); }

        set { playerPosition = value.playerPosition; creaturesPosition = value.creaturesPosition; }
    }

    //======================================
    // Méthodes
    //======================================

    public void AddCreaturePosition(float x, float y, long id, Type type) {
        this.creaturesPosition.Add(new Pair<float, float>(x, y), new LivingThingData(id, type));
    }

    public void Init(Pair<float, float> playerPosition, Dictionary<Pair<float, float>, LivingThingData> creaturesPosition) {
        this.playerPosition = playerPosition;
        this.creaturesPosition = creaturesPosition;
    }

    private void OnEnable() {
        this.playerPosition = new Pair<float, float>();
        this.creaturesPosition = new Dictionary<Pair<float, float>, LivingThingData>();
    }
}
