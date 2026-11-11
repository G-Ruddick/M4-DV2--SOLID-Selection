﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour {
    private ISelectionResponse selectionResponse;
    private IRayProvider rayProvider;
    private ISelector selector;

    private Transform currentSelection;

    private void Awake() {
        SceneManager.LoadScene("Environment", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);

        selectionResponse = GetComponent<ISelectionResponse>();
        rayProvider = GetComponent<IRayProvider>();
        selector = GetComponent<ISelector>();
    }

    private void Update() {
        if (currentSelection != null) {
            selectionResponse.OnDeselect(currentSelection);
        }

        selector.Check(rayProvider.CreateRay());
        currentSelection = selector.GetSelection();

        if (currentSelection != null) {
            selectionResponse.OnSelect(currentSelection);
        }
    }
}