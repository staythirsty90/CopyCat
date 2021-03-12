using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UISetScore : MonoBehaviour, IOnGameOver {
    public float delay;
    [SerializeField]
    private Image onesPlace = null;
    [SerializeField]
    private Image tensPlace = null;
    [SerializeField]
    private Image hundredsPlace = null;
    private int currentScore;

    public void OnGameOver() {
        StartCoroutine(ShowScore());
    }

    IEnumerator ShowScore() {
        float t = 0;
        while (t < delay) {
            yield return null;
            t += Time.deltaTime;
        }
        ShowScoreUI();
    }

    void ShowScoreUI() {
        if (currentScore >= 100) {
            tensPlace.enabled = true;
            tensPlace.color = new Color32(255, 255, 255, 255);
            hundredsPlace.enabled = true;
            hundredsPlace.color = new Color32(255, 255, 255, 255);
        }
        else if (currentScore >= 10) {
            tensPlace.enabled = true;
            tensPlace.color = new Color32(255, 255, 255, 255);
        }

        onesPlace.enabled = true;
        onesPlace.color = new Color32(255, 255, 255, 255);

    }

    public void SetScore(GameDigits gameDigits, int score) {
        if (score < 0) {
            Debug.LogWarning("score was negative...");
            return;
        }
        currentScore = score;
        int place = score % 10;
        onesPlace.sprite = gameDigits.GameDigit[place];
        place = (score = score / 10) % 10;
        // if ( place > 0 )
        //  {
        //   tensPlace.enabled = true;
        //    tensPlace.color = new Color32(255, 255, 255, 255);
        tensPlace.sprite = gameDigits.GameDigit[place];
        // }
        place = (score = score / 10) % 10;
        // if (place > 0)
        // {
        //    hundredsPlace.enabled = true;
        //  hundredsPlace.color = new Color32(255, 255, 255, 255);
        hundredsPlace.sprite = gameDigits.GameDigit[place];
        //}


    }
}
