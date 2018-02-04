using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

[System.Serializable]
public class OrganismData {
    public Health health;
    public Hunger hunger;

    public OrganismData(Health health, Hunger hunger) {
        this.health = health;
        this.hunger = hunger;
    }
}

[CreateAssetMenu(fileName = "Data", menuName = "+Scriptable Objects/Organism", order = 1)]
public class Organism : DataManager<OrganismData> {

    [SerializeField]
    private Health health;

    [SerializeField]
    private Hunger hunger;


    public float Health {
        get { return this.health.Current; }
        private set { }
    }

    public float MaxHealth {
        get { return this.health.Max; }
        private set { }
    }

    public float MaxHunger {
        get { return this.hunger.Max; }
        private set { }
    }

    public float Hunger {
        get { return this.hunger.Current; }
        private set { }
    }

    protected override OrganismData Data {
        get {  return new OrganismData(health, hunger); }
        set {  health = value.health; hunger = value.hunger; }
    }

    //======================================
    // Méthodes
    //======================================

    public void Live() {

        //Debug.Log(health);
        if (this.hunger.Current / this.hunger.Max > 0.5) {
            this.health.Increase(this.health.Variation);
        }
        else if (this.hunger.Current == 0) {
            this.health.Increase(-this.health.Variation);
        }

        this.hunger.Deacrease(this.hunger.Variation);
        //this.hunger
    }

    public void Suffer(int amount) {
        this.health.Deacrease(amount);
    }

    // Use this for initialization
    void OnEnable() {
    }

}
