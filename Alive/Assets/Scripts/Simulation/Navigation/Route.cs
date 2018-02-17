using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route {

    public string description;
    public string scene;
    public string spawn;

    public Route(string description, string scene, string spawn) {
        this.description = description;
        this.scene = scene;
        this.spawn = spawn;
    }
}
