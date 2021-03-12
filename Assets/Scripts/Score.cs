using System;
using UnityEngine;

public class Score : MonoBehaviour, IOnGameOver, IOnGameRestart {
    private int score = 0;
    private int highScore = 0;
    public int GameScore {
        get { return score; }
    }
    public int HighScore {
        get { return highScore; }
        set {
            highScore = value;
            //Debug.Log("changing highscore to : " + value);
            OnHighScoreChanged?.Invoke(highScore);
        }
    }
    public static Action<int> OnHighScoreChanged;
    //UIHandler uiHandler;
    CopyCat copyCat;
    void Awake() {
        //uiHandler = FindObjectOfType<UIHandler>();
        score = 0;
        copyCat = FindObjectOfType<CopyCat>();
    }

    public void OnGameRestart() {
        score = 0;
        copyCat.NotifyListeners(typeof(IOnScorePoint), score);
    }

    public void AddScore(int amount) {
        score += amount;
        copyCat.NotifyListeners(typeof(IOnScorePoint), score);
        if (score > highScore) {
            OnHighScoreChanged?.Invoke(score);
            highScore = score;
        }
    }
    public void OnGameOver() {
        if (score >= highScore) {
            Save();
        }
    }

    void Save() {
#if !UNITY_EDITOR
        //uiHandler.AddScore((uint)score);
#endif
    }
}
