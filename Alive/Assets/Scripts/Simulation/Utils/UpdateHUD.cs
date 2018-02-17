using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHUD : MonoBehaviour {

    [SerializeField]
    private Player player;

    [SerializeField]
    private RectTransform rectHealth;
    [SerializeField]
    private RectTransform rectHunger;

    private float maxWidth;
    private float maxHealth;
    private float maxHunger;

    // Use this for initialization
    void Start () {
        this.maxWidth = this.rectHealth.rect.width;
    }
	
	void FixedUpdate () {
        // Update Health Bar
        this.rectHealth.sizeDelta = new Vector2((float)((this.player.Organism.Health / this.player.Organism.MaxHealth) * this.maxWidth), (float)(this.rectHealth.rect.height));

        // Update Hunger Bar
        this.rectHunger.sizeDelta = new Vector2((float)((this.player.Organism.Hunger / this.player.Organism.MaxHunger) * this.maxWidth), (float)(this.rectHunger.rect.height));
    }
}
