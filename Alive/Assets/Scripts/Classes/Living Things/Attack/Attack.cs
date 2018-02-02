using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Attack{

    [SerializeField] 
    protected List<WeaponType> weaponType;
    public List<WeaponType> WeaponType {
        get { return weaponType; }
        protected set { }
    }
}
