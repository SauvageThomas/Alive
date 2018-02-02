using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingThing : MonoBehaviour, ITakeDamage, Identifiable {

    public string Name {
        get { return _Name; }
        private set { }
    }
    [SerializeField]
    private string _Name;

    public int Speed {
        get { return _Speed; }
        private set { }
    }
    [SerializeField]
    private int _Speed;

    [SerializeField]
    private Organism organism;
    public Organism Organism {
        get { return organism; }
        private set { }
    }

    [SerializeField]
    private Protection protection;
    public Protection Protection {
        get { return protection; }
        private set { }
    }

    protected int Age;
    protected string Faction;
    protected string Occupation;
    protected int Level = 1;
    protected int Health = 2;
    protected int Strength = 1;
    protected int Magic = 0;
    protected int Defense = 0;
    protected int NoOfAttacks = 1;
    protected string Weapon;
    protected Vector2 Position;
    private long id;

    //public void Attack(LivingThing Entity) { Entity.TakeDamage(Strength); }

    // Use this for initialization
    void Awake() {
        //this.organism = ScriptableObject.CreateInstance(typeof(Organism)) as Organism;
        //this.organism = AssetBundle.LoadAsset("Organism.asset", typeof(Organism)) as Organism;
        this.id = Toolbox.Instance.getID();
        DontDestroyOnLoad(gameObject);

        this.organism = Instantiate(this.organism); //Make a local copy in order to be able to modify it

    }

    // Update is called once per frame
    void FixedUpdate() {
        this.organism.Live();
    }

    public void TakeDamage(Damage damage) {
        this.protection.Absorb(damage);
        this.organism.Suffer(damage.Amount);
        damage.Touch(this);
    }

    public void Save() {
        this.organism.Save(this.GetType().Name, this.id);
    }

    public void Load() {
        this.organism.Load(this.GetType().Name, this.id);
    }

    long Identifiable.GetID() {
        return this.id;
    }

    void OnApplicationQuit() {
        this.Save();
    }
}
