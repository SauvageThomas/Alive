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

    protected long id = -1;

    //public void Attack(LivingThing Entity) { Entity.TakeDamage(Strength); }

    // Use this for initialization
    protected virtual void Awake() {
        //this.organism = ScriptableObject.CreateInstance(typeof(Organism)) as Organism;
        //this.organism = AssetBundle.LoadAsset("Organism.asset", typeof(Organism)) as Organism;
        this.organism = Instantiate(this.organism);
        //DontDestroyOnLoad(gameObject);

    }

    protected virtual void Start() {


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
        this.organism.Save(this.organism.GetType().Name + "_" + id);
        //new LivingThingLoader(gameObject.transform.position.x, gameObject.transform.position.y).Save(this.GetType().Name, this.id);

    }

    public void Load(float x, float y, long id) {
        gameObject.SetActive(true);
        this.id = id;

        this.organism.Load(this.organism.GetType().Name + "_" + id);

        /*LivingThingLoader loader = new LivingThingLoader();
        loader.Load(this.GetType().Name, this.id);*/
        gameObject.transform.position = new Vector3(x, y, 0);

    }

    public virtual long GetID() {
        return this.id;
    }

    public virtual void SetID(long id) {
        this.id = id;
    }

    void OnApplicationQuit() {
        this.Save();
    }

    /*public bool IsVisible() {
        Vector3 pos = Camera.current.WorldToViewportPoint(transform.position);
        return pos.x >= 0.0f && pos.x <= 1.0f && pos.y >= 0.0f && pos.y <= 1.0f;
    }*/

    public void SetActive(bool active) {
        gameObject.SetActive(active);
    }

    public void Destroy() {
        Destroy(gameObject);
    }

    public void Move(Transform transform) {
        this.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
