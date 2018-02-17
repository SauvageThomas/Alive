using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Health : CountableValue {

    /*
    [SerializeField]
    private float repeatDamagePeriod = 2f;       // How frequently the player can be damaged.
    public float RepeatDamagePeriod {
        get { return repeatDamagePeriod; }
        private set { }
    }

    private AudioClip[] ouchClips;               // Array of clips to play when the player is damaged.
    public AudioClip[] OuchClips {
        get { return ouchClips; }
        private set { }
    }

    [SerializeField]
    private float hurtForce = 10f;               // The force with which the player is pushed when hurt.
    public float HurtForce {
        get { return hurtForce; }
        private set { }
    }

   

    private SpriteRenderer healthBar;           // Reference to the sprite renderer of the health bar.
    private float lastHitTime;                  // The time at which the player was last hit.
    private Vector3 healthScale;                // The local scale of the health bar initially (with full health).
    private PlayerControl playerControl;        // Reference to the PlayerControl script.
    private Animator anim;                      // Reference to the Animator on the player
    */


    // Use this for initialization
    public Health() {
        this.current = this.max;
    }
}
