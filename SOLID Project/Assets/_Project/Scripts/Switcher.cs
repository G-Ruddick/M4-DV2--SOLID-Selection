using UnityEngine;
using System.Collections.Generic;

public class Switcher : MonoBehaviour {
    public List<GameObject> changeableObjects;
    private List<IChangeable> changeables = new List<IChangeable>();

    private void Start() {
        for (int i = 0; i < changeableObjects.Count; i++) {
            changeables.Add(changeableObjects[i].GetComponent<IChangeable>());
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            for (int i = 0; i < changeables.Count; i++) {
                changeables[i].Next();
            }
        }
    }
}
