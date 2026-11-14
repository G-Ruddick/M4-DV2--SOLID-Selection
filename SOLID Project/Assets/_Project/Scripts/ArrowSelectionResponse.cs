using UnityEngine;

internal class ArrowSelectionResponse : MonoBehaviour, ISelectionResponse {
    public void OnDeselect(Transform selection) {
        var selectionRenderer = selection.GetChild(0);

        if (selectionRenderer != null) {
            selectionRenderer.gameObject.SetActive(false);
        }
    }

    public void OnSelect(Transform selection) {
        var selectionRenderer = selection.GetChild(0);

        if (selectionRenderer != null) {
            selectionRenderer.gameObject.SetActive(true);
        }
    }
}