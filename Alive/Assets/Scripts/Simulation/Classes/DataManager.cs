using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization;

public abstract class DataManager<T> : ScriptableObject {

    protected abstract T Data {
        get;
        set;
    }

    public void Save(string path) {
        Toolbox.SaveScriptableObject<T>(path, this.Data);
        Debug.Log("Saving " + this.Data + " at " + path);
    }

    public bool Load(string path) {
        T tmp = Toolbox.LoadScriptableObject<T>(path);
        if (tmp != null) {
            this.Data = tmp;
            Debug.Log("Data Loaded at " + path);
            return true;
        }
        else {
            Debug.Log("Failed to load at " + path);
            return false;
        }
    }

}