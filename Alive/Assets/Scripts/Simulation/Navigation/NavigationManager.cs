using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : Singleton<NavigationManager> {

    [SerializeField]
    private bool navigate = true;
    public bool Navigate {
        get { return navigate; }
        set { navigate = value; }
    }

    public Dictionary<string, string> RouteInformation = new Dictionary<string, string>() {
    { "World", "The big bad world"},
    { "Cave", "The deep dark cave"},};

    public string GetRouteInfo(string destination) {
        return RouteInformation.ContainsKey(destination) ? RouteInformation[destination] : null;
    }

    public void NavigateTo(string destination) {
        if (this.navigate) {
            this.navigate = false;
            Debug.Log("Loading Scene : " + destination);
            Route route = new Route(destination, destination, SceneManager.GetActiveScene().name);
            GameManager.Instance.NavigateTo(route);
        }

    }


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
