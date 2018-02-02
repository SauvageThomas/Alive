using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Armor {

    [SerializeField]
    private int amount = 2;
    public int Amount {
        get { return amount; }
        private set { }
    }

    [SerializeField]
    private int weight = 1;
    public int Weight {
        get { return weight; }
        private set { }
    }

}
