using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreManager : MonoBehaviour, IOnScorePoint, IOnGameOver, IOnGameRestart {
    [SerializeField]
    private int scoreAmount = 1;
    private Text scoreText;
    [SerializeField]
    private Text endScoreText = null;
    [SerializeField]
    private Text endHighScoreText = null;

    public int Score { get; set; }
    public int HighScore { get; set; }
    public bool NewHighScore { get; private set; } = false;
    private RectTransform thisRectTransform;
    private CopyCat copyCat;
    private Vector2 startingPosition;

    void Awake() {
        copyCat = FindObjectOfType<CopyCat>();
        thisRectTransform = GetComponent<RectTransform>();
        scoreText = GetComponent<Text>();
        startingPosition = thisRectTransform.anchoredPosition;
    }

    public void OnScorePoint(int score) {
        if (score == 0) {
            return;
        }
        Score += scoreAmount;
        if (Score > HighScore) {
            HighScore = Score;
            NewHighScore = true;
        }
        scoreText.text = Score.ToString();
    }

    public void OnGameRestart() {
        Score = 0;
        copyCat.EventManager.NotifyListeners_OnScorePoint(Score);
        thisRectTransform.anchoredPosition = startingPosition;
        scoreText.text = Score.ToString();
        NewHighScore = false;
    }

    public void OnGameOver() {
        if (Score >= HighScore) {
            Save();
        }
        endScoreText.text = scoreText.text;
        endHighScoreText.text = HighScore.ToString();
        
    }

    void Save() {
#if !UNITY_EDITOR
        //uiHandler.AddScore((uint)score);
#endif
    }

}
