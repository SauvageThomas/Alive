using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class CountableValue {

    [SerializeField]
    protected float max = 100f;                 // The player's health.
    public float Max {
        get { return max; }
        protected set { }
    }

    [SerializeField]
    protected float variation = 0.01f;                 // The player's regeneration.
    public float Variation {
        get { return variation; }
        protected set { }
    }

    [SerializeField]
    protected float current;
    public float Current {
        get { return current; }
        protected set { }
    }

    public void Increase(float amount) {
        this.current = Mathf.Min(this.max, this.current + amount);
    }

    public void Deacrease(float amount) {
        this.current = Mathf.Max(0, this.current - amount);
    }
}
