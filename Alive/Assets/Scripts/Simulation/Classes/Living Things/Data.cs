using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public class Data {

    public static Data current;
    public Character knight;
    public Character rogue;
    public Character wizard;

    public Data() {
        knight = new Character();
        rogue = new Character();
        wizard = new Character();
    }

}
