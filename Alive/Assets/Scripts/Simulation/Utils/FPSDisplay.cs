using UnityEngine;
using System.Collections;

public class FPSDisplay : MonoBehaviour {
    private float deltaTime = 0.0f;
    private UnityEngine.UI.Text text;

    void Start() {
        this.text = GetComponent<UnityEngine.UI.Text>();
    }


    void Update() {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI() {

        int fps = (int) (1 / deltaTime);

        this.text.text = fps.ToString();

        if (fps > 45) {
            this.text.color = Color.black;
        }
        else if (fps > 30) {
            this.text.color = Color.yellow;
        }
        else {
            this.text.color = Color.red;
        }
    }
}