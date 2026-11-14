using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private void Awake() {
        this.gameObject.SetActive(false);
    }

    private void OnEnable() {
        this.Update();
    }

    private void Update() {
        this.transform.rotation = Camera.main.transform.rotation;
    }
}
