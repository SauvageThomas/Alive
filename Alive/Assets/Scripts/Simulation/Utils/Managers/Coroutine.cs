using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour {

    IEnumerator Print10Lines() {
        for (int i = 0; i < 10; i++) {
            print("Line" + i.ToString());
            yield return new WaitForSeconds(2);
        }
    }
}
