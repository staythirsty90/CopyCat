﻿using UnityEngine;

public class AddScoreOnTrigger : MonoBehaviour {
    CopyCat copyCat;
    private void Awake() {
        copyCat = FindObjectOfType<CopyCat>();
    }
    
    void OnTriggerEnter2D() {
        if (!copyCat.IsGameOver) {
            copyCat.EventManager.NotifyListeners_OnScorePoint(-1);
        }
    }
}
