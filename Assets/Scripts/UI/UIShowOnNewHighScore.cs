using System.Collections;
using UnityEngine;

public class UIShowOnNewHighScore : UIMonoBehaviour, IOnGameOver, IOnGameRestart {
    ScoreManager scoreManager;
    protected override void Awake() {
        base.Awake();
        scoreManager = FindObjectOfType<ScoreManager>();
        thisImage.enabled = false;
    }
    public void OnGameOver() {
        if (scoreManager.NewHighScore) { 
            StartCoroutine(FadeIn());
        }
    }
    public void OnGameRestart() {
        thisImage.enabled = false;
    }
}
