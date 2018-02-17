using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : Singleton<NavigationManager> {

    public static Dictionary<string, string> RouteInformation = new Dictionary<string, string>() {
    { "World", "The big bad world"},
    { "Cave", "The deep dark cave"},};

    public static string GetRouteInfo(string destination) {
        return RouteInformation.ContainsKey(destination) ? RouteInformation[destination] : null;
    }

    public static bool CanNavigate(string destination) {
        return true;
    }

    public static void NavigateTo(string destination) {
        Debug.Log("Loading Scene : " + destination);
        Route route = new Route(destination, destination, SceneManager.GetActiveScene().name);
        GameManager.Instance.NavigateTo(route);
        
    }


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
