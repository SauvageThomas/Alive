using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Awake() {
        // Your initialization code here
    }

    // (optional) allow runtime registration of global objects
    static public T RegisterComponent<T>() where T : Component {
        return Instance.GetOrAddComponent<T>();
    }
}

[System.Serializable]
public class Language {
    public string current;
    public string lastLang;
}