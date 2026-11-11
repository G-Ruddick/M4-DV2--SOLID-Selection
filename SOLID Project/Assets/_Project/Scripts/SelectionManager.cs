﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionManager : MonoBehaviour {
    [SerializeField] private string selectableTag = "Selectable";

    private ISelectionResponse selectionResponse;

    private Transform _selection;

    private void Awake() {
        SceneManager.LoadScene("Environment", LoadSceneMode.Additive);
        SceneManager.LoadScene("UI", LoadSceneMode.Additive);

        selectionResponse = GetComponent<ISelectionResponse>();
    }

    private void Update() {
        if (_selection != null) {
            selectionResponse.OnDeselect(_selection);
        }

        #region MyRegion
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        _selection = null;
        if (Physics.Raycast(ray, out var hit)) {
            var selection = hit.transform;

            if (selection.CompareTag(selectableTag)) {
                _selection = selection;
            }
        }
        #endregion

        if (_selection != null) {
            selectionResponse.OnSelect(_selection);
        }
    }
}