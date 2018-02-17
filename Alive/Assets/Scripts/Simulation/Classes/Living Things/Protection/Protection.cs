using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProtectionData {
    public Armor armor;
}

[CreateAssetMenu(fileName = "Data", menuName = "+Scriptable Objects/Protection", order = 1)]
public class Protection : DataManager<ProtectionData> {


    [SerializeField]
    private ProtectionData data;
    public override ProtectionData Data {
        get { return data; }
        protected set { data = value; }
    }    

    public void Absorb(Damage Damage) {
        Damage.Reduce(this.data.armor.Amount);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
