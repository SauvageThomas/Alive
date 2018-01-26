using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingThing : ScriptableObject {

    protected string Name;
    protected int Age;
    protected string Faction;
    protected string Occupation;
    protected int Level = 1;
    protected int Health = 2;
    protected int Strength = 1;
    protected int Magic = 0;
    protected int Defense = 0;
    protected int Speed = 1;
    protected int Damage = 1;
    protected int Armor = 0;
    protected int NoOfAttacks = 1;
    protected string Weapon;
    protected Vector2 Position;


    public void TakeDamage(int Amount) {
        Health -= Mathf.Clamp((Amount - Armor), 0, int.MaxValue);
    }

    public void Attack(LivingThing Entity) { Entity.TakeDamage(Strength); }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
