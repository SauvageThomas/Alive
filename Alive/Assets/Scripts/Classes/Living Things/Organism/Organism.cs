using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

[System.Serializable]
public class OrganismData {
    public Health health;
    public Hunger hunger;
}

[CreateAssetMenu(fileName = "Data", menuName = "+Scriptable Objects/Organism", order = 1)]
public class Organism : DataManager<OrganismData> {

    [SerializeField]
    private OrganismData data;
    public override OrganismData Data {
        get { return data; }
        protected set { data = value; }
    }

    public float Health {
        get { return this.data.health.Current; }
        private set { }
    }

    public float MaxHealth {
        get { return this.data.health.Max; }
        private set { }
    }

    public float MaxHunger {
        get { return this.data.hunger.Max; }
        private set { }
    }

    public float Hunger {
        get { return this.data.hunger.Current; }
        private set { }
    }

    //======================================
    // Méthodes
    //======================================

    public void Live() {

        //Debug.Log(health);
        if (this.data.hunger.Current / this.data.hunger.Max > 0.5) {
            this.data.health.Increase(this.data.health.Variation);
        }
        else if (this.data.hunger.Current == 0) {
            this.data.health.Increase(-this.data.health.Variation);
        }

        this.data.hunger.Deacrease(this.data.hunger.Variation);
        //this.hunger
    }

    public void Suffer(int amount) {
        this.data.health.Deacrease(amount);
    }

    // Use this for initialization
    void OnEnable() {
    }

}
