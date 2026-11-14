using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CompositeSelectionResponse : MonoBehaviour, ISelectionResponse, IChangeable {
    [SerializeField] private GameObject selectionResponseHolder;
    
    private List<ISelectionResponse> selectionResponses;
    private int currentIndex;
    private Transform currentSelection;

    private void Start() {
        selectionResponses = selectionResponseHolder.GetComponents<ISelectionResponse>().ToList();
    }

    public void OnDeselect(Transform selection) {
        currentSelection = null;

        if (HasSelection()) {
            selectionResponses[currentIndex].OnDeselect(selection);
        }
    }

    public void OnSelect(Transform selection) {
        currentSelection = selection;

        if (HasSelection()) {
            selectionResponses[currentIndex].OnSelect(selection);
        }
    }

    [ContextMenu("Next")]
    public void Next() {
        if (currentSelection != null) {
            selectionResponses[currentIndex].OnDeselect(currentSelection);
        }
        
        currentIndex = (currentIndex + 1) % selectionResponses.Count;
        selectionResponses[currentIndex].OnSelect(currentSelection);
    }

    private bool HasSelection() {
        return currentIndex > -1 && currentIndex < selectionResponses.Count;
    }
}