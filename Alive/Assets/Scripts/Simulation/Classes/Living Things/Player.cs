using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : LivingThing {


    protected string[] Inventory;
    protected string[] Skills;
    protected int Money;

    protected override void Awake() {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public override long GetID() {
        return 0;
    }

    // Use this for initialization
    protected override void Start () {
        this.id = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}





}
