using UnityEngine;
using System.Collections;

[System.Serializable]
public class Character {

    public string name;
    [SerializeField]
    private int life;

    public Character() {
        this.name = "";
        this.life = 5;
    }
}