using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugObject : MonoBehaviour {

    // Use this for initialization
    void Start() {
        if (!Toolbox.Instance.debug) {
            Component[] components = GetComponents(typeof(Component));

            foreach (Component component in components) {
                Destroy(component);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
