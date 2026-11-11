using UnityEngine;

public class RayCastBasedTagSelector : MonoBehaviour, ISelector {
    [SerializeField] public string selectableTag = "Selectable";
    
    private Transform selection;

    public void Check(Ray ray) {
        this.selection = null;

        if (Physics.Raycast(ray, out var hit)) {
            var selection = hit.transform;

            if (selection.CompareTag(this.selectableTag)) {
                this.selection = selection;
            }
        }
    }

    public Transform GetSelection() {
        return selection;
    }
}
