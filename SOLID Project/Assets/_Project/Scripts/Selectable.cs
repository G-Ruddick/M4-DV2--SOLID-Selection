using UnityEngine;
using TMPro;

public class Selectable : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI lookPercentageLabel;

    [HideInInspector] public float lookPercentage;

    void Update() {
        lookPercentageLabel.text = lookPercentage.ToString("F3");
    }
}
