using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour, IOnScorePoint, IOnGameOver, IOnGameRestart {
    [SerializeField]
    private GameDigits gameDigits = null;
    [SerializeField]
    private int scoreAmount = 1;
    [SerializeField]
    private Image newImage = null;
    [SerializeField]
    private Image onesPlace = null;
    [SerializeField]
    private Image tensPlace = null;
    [SerializeField]
    private Image hundredsPlace = null;
    
    public int Score { get; set; }
    public int HighScore { get; set; }

    private RectTransform thisRectTransform;
    private CopyCat copyCat;
    private Vector2 startingPosition;
    private float moveOffset = 22f;

    void Awake() {
        copyCat = FindObjectOfType<CopyCat>();
        thisRectTransform = GetComponent<RectTransform>();
        startingPosition = thisRectTransform.anchoredPosition;
        moveOffset = onesPlace.rectTransform.sizeDelta.x;
    }

    public void OnScorePoint(int score) {
        if (score == 0) {
            return;
        }
        Score += scoreAmount;
        if (Score > HighScore) {
            HighScore = Score;
        }
        SetDigits();
        MoveScorePosition();
    }

    void SetDigits() {
        (int ones, int tens, int hunds) = GetDigitPlaces();
        if (hunds > 0) {
            ShowDigit(hundredsPlace,hunds);
        }
        if (tens > 0 || hunds > 0) {
            ShowDigit(tensPlace, tens);
        }
        ShowDigit(onesPlace, ones);
    }

    private void ShowDigit(Image img, int place) {
        img.enabled = true;
        img.sprite = gameDigits.GameDigit[place];
        img.color = new Color(1f, 1f, 1f, 1f);
    }

    (int, int, int) GetDigitPlaces() {
        int score = Score;
        int onesPlace = score % 10;
        score /= 10;
        int tensPlace = score % 10;
        score /= 10;
        int hundredsPlace = score % 10;
        return (onesPlace, tensPlace, hundredsPlace);
    }

    void MoveScorePosition() {
        Vector2 pos = startingPosition;
        if (hundredsPlace.enabled) {
            pos.x += moveOffset;
        }
        if (tensPlace.enabled) {
            pos.x += moveOffset;
        }
        thisRectTransform.anchoredPosition = pos;
    }

    public void OnGameRestart() {
        Score = 0;
        copyCat.NotifyListeners(typeof(IOnScorePoint), Score);
        thisRectTransform.anchoredPosition = startingPosition;
    }

    public void OnGameOver() {
        if (Score >= HighScore) {
            Save();
        }
    }

    void Save() {
#if !UNITY_EDITOR
        //uiHandler.AddScore((uint)score);
#endif
    }

}
