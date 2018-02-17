using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hunger : CountableValue {

   

    // Use this for initialization
    public Hunger() {
        this.current = this.max;
    }

}
