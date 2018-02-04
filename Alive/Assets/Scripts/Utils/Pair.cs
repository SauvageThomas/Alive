using UnityEngine;
using System.Collections;
using System.Runtime.Serialization;

[System.Serializable]
public class Pair<T, U> {
    public Pair() {
    }

    public Pair(T first, U second) {
        this.first = first;
        this.second = second;
    }

    public T first;
    public U second;
};

