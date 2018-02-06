using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : LivingThing {

    protected override void Awake() {
        base.Awake();
        GameManager.Instance.Register(this);
    }

    // Use this for initialization
    protected override void Start() {
        base.Start();

    }
	
	// Update is called once per frame
	void Update () {
		
	}   
}
