using UnityEngine;
using System.Collections;

public abstract class Weapon {

    [SerializeField]
    protected WeaponType weaponType;
    public WeaponType WeaponType {
        get { return weaponType; }
        protected set { }
    }
}
