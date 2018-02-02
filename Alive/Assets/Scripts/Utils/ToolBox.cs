﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

static public class MethodExtensionForMonoBehaviourTransform {
    /// <summary>
    /// Gets or add a component. Usage example:
    /// BoxCollider boxCollider = transform.GetOrAddComponent<BoxCollider>();
    /// </summary>
    static public T GetOrAddComponent<T>(this Component child) where T : Component {
        T result = child.GetComponent<T>();
        if (result == null) {
            result = child.gameObject.AddComponent<T>();
        }
        return result;
    }
}


public class Toolbox : Singleton<Toolbox> {
    protected Toolbox() { } // guarantee this will be always a singleton only - can't use the constructor!

    public bool debug = true;
    public Language language = new Language();
    public string dataExtension = ".ale";
    public string saveDirectory = "data";
    public string playerSaveDirectory = "player";

    private long maxID;
    private List<MonoBehaviour> dataLoaded;

    void Awake() {
        this.maxID = 0;
    }

    public long getID() {
        long id = this.maxID;
        this.maxID += 1;
        return id;
    }

    // (optional) allow runtime registration of global objects
    static public T RegisterComponent<T>() where T : Component {
        return Instance.GetOrAddComponent<T>();
    }

    public static string CombineSaveDirectoryPath(string fileName) {
        string path = Path.Combine(Application.persistentDataPath, Instance.saveDirectory);
        return Path.Combine(path, fileName);
    }

    public static void CreateDirectory(string dirpPath) {
        if (!SaveDirectoryExists(dirpPath)) {
            Directory.CreateDirectory(dirpPath);
        }
    }

    public static void SaveScriptableObject<T>(string path, long id, T serializableObject) {
        path = CombineSaveDirectoryPath(path);

        BinaryFormatter bf = new BinaryFormatter();

        CreateDirectory(Path.GetDirectoryName(path));
        FileStream stream = File.Create(path + "_" + id + Instance.dataExtension);
        Debug.Log("Saving at " + path);
        Debug.Log("The object " + serializableObject);
        bf.Serialize(stream, serializableObject);

        stream.Close();
    }

    public static T LoadScriptableObject<T>(string path, long id) {

        path = CombineSaveDirectoryPath(path) + "_" + id + Instance.dataExtension;
        Debug.Log("Loading at " + path);

        T serializableObject = default(T);
        if (File.Exists(path)) {
            Debug.Log("Le ficher existe");

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);

            serializableObject = (T)bf.Deserialize(file);
            file.Close();
        }
        return serializableObject;
    }

    public static bool SaveDirectoryExists(string directoryName) {
        return Directory.Exists(Path.Combine(Application.persistentDataPath, directoryName));
    }

    [System.Serializable]
    public class Language {
        public string current;
        public string lastLang;
    }
}