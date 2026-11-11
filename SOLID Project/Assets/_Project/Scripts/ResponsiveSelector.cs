using UnityEngine;
using System.Collections.Generic;

public class ResponsiveSelector : MonoBehaviour, ISelector {
    [SerializeField] private List<Selectable> selectables;
    [SerializeField] private float threshold = 0.97f;

    private Transform selection;

    public void Check(Ray ray) {
        selection = null;
        var closest = 0.0f;

        for (int i = 0; i < selectables.Count; i++) {
            var vector1 = ray.direction;
            var vector2 = selectables[i].transform.position - ray.origin;
            var lookPercentage = Vector3.Dot(vector1.normalized, vector2.normalized);

            selectables[i].lookPercentage = lookPercentage;
            
            if (lookPercentage > threshold && lookPercentage > closest) {
                closest = lookPercentage;
                selection = selectables[i].transform;
            }
        }
    }

    public Transform GetSelection() {
        return selection;
    }
}
