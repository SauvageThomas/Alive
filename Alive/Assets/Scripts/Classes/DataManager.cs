using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization;

public abstract class DataManager<T> : ScriptableObject {

    public abstract T Data {
        get;
        protected set;
    }

    public void Save(string path, long id) {
        Toolbox.SaveScriptableObject<T>(Path.Combine(path, this.GetType().Name), id, this.Data);
        Debug.Log("Data Saved at " + path + "_" + id);
    }

    public void Load(string path, long id) {
        T tmp = Toolbox.LoadScriptableObject<T>(Path.Combine(path, this.GetType().Name), id);
        if (tmp != null) {
            this.Data = tmp;
            Debug.Log("Data Loaded at " + path + "_" + id);
        }
    }

}