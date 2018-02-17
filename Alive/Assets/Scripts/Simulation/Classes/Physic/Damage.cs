using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    [SerializeField]
    private string attack;
    public string Attack {
        get { return attack; }
        private set { }
    }
    
    [SerializeField]
    private int amount;
    public int Amount {
        get { return amount; }
        private set { }
    }
    


    // Use this for initialization
    void Start () {
		
	}

    internal void Reduce(int amount) {
        this.amount = Math.Min(0, this.amount - amount);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Touch(ITakeDamage Damageable) {
        //TODO: implement me
    }
}
