using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization;

public abstract class DataManager<T> : ScriptableObject {

    protected abstract T Data {
        get;
        set;
    }

    public void Save(string path, long id) {

        Toolbox.SaveScriptableObject<T>(Path.Combine(path, this.GetType().Name), id, this.Data);

        Debug.Log("Data Saved at " + path + "_" + id);
    }

    public void Save(string path) {
        Toolbox.SaveScriptableObject<T>(path, this.Data);
        Debug.Log("Data Saved at " + path);
    }

    public bool Load(string path, long id) {
        T tmp = Toolbox.LoadScriptableObject<T>(Path.Combine(path, this.GetType().Name), id);
        if (tmp != null) {
            this.Data = tmp;
            Debug.Log("Data Loaded at " + Path.Combine(path, this.GetType().Name) + "_" + id);
            return true;
        }
        else {
            Debug.Log("Failed to load at " + Path.Combine(path, this.GetType().Name) + "_" + id);
            return false;
        }
    }

    public bool Load(string path) {
        T tmp = Toolbox.LoadScriptableObject<T>(path, -1);
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