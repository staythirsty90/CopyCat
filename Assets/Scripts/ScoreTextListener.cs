using UnityEngine;
using UnityEngine.UI;

public class ScoreTextListener : MonoBehaviour, IOnGameOver, IOnGameRestart, IOnScorePoint {
    private Image onesPlace;
    private Image tensPlace;
    private Image hundredsPlace;
    public float moveOffset;
    [SerializeField]
    private GameDigits gameDigits = null;
    [SerializeField]
    private UISetScore uiSetScore = null;
    [SerializeField]
    private UISetScore uiSetHighScore = null;


    private RectTransform thisRectTransform;
    private Vector2 startingPosition;
    private Score score;

    void Awake() {
        thisRectTransform = GetComponent<RectTransform>();
        startingPosition = thisRectTransform.anchoredPosition;
        score = FindObjectOfType<Score>();

        onesPlace = transform.GetChild(0).GetComponent<Image>();
        tensPlace = transform.GetChild(1).GetComponent<Image>();
        hundredsPlace = transform.GetChild(2).GetComponent<Image>();
    }

    void Start() {
        setHighScore();
    }

    public void setHighScore() {
        uiSetHighScore.SetScore(gameDigits, score.HighScore);
    }
    public void OnGameOver() {
        uiSetHighScore.SetScore(gameDigits, score.HighScore);
    }

    public void OnGameRestart() {
        thisRectTransform.anchoredPosition = startingPosition;
    }
    void GetOneDigit(int score) {
        if (score < 10) {
            int place = score % 10;
            onesPlace.sprite = gameDigits.GameDigit[place];
        }
        else {
            GetTwoDigits(score);
            MoveScorePosition();
        }
    }

    void GetTwoDigits(int score) {
        if (score < 100) {
            int place = score % 10;
            onesPlace.sprite = gameDigits.GameDigit[place];
            place = (score = score / 10) % 10;
            tensPlace.sprite = gameDigits.GameDigit[place];
        }
        else {
            GetThreeDigits(score);
            MoveScorePosition();
        }
    }

    void GetThreeDigits(int score) {
        int place = score % 10;
        onesPlace.sprite = gameDigits.GameDigit[place];
        place = (score = score / 10) % 10;
        tensPlace.sprite = gameDigits.GameDigit[place];
        place = (score = score / 10) % 10;
        hundredsPlace.sprite = gameDigits.GameDigit[place];
    }

    void MoveScorePosition() {
        Vector2 pos = thisRectTransform.anchoredPosition;
        pos.x += moveOffset;
        thisRectTransform.anchoredPosition = pos;
    }

    public void OnScorePoint(int score) {
        uiSetScore.SetScore(gameDigits, score);
    }
}
