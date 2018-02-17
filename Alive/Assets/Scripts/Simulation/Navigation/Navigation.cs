using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour {

    [SerializeField]
    private string[] nextScenes;

    void OnCollisionExit2D(Collision2D col) {
        //TODO: Create a GUI to chose the right scene, for now take the first
        NavigationManager.NavigateTo(nextScenes[0]);
    }
}
