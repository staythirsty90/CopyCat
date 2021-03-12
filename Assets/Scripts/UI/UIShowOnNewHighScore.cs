using System.Collections;
using UnityEngine;

public class UIShowOnNewHighScore : UIMonoBehaviour, IOnGameOver, IOnGameRestart {
    bool show = false;

    void Start() {
        thisImage.enabled = false;
    }

    void OnEnable() {
        Score.OnHighScoreChanged += OnHighScoreChanged;
    }

    void OnDisable() {
        Score.OnHighScoreChanged -= OnHighScoreChanged;
    }

    public void OnGameOver() {
        if (show) {
            StartCoroutine(Show());
        }
    }

    void OnHighScoreChanged(int score) {
        show = true;
    }

    public void OnGameRestart() {
        show = false;
        thisImage.enabled = false;
    }

    IEnumerator Show() {
        float t = 0;
        while (t < delay) {
            yield return null;
            t += Time.deltaTime;
        }
        StartCoroutine(CrossFade(thisImage, 0, 1, 0.3f));
    }
}
