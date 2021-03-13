using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class MedalReward : UIMonoBehaviour, IOnGameOver, IOnGameRestart {
    public Sprite emptySprite;
    private ScoreManager scoreManager;

    public MedalData[] medalDatas;
    private Image myImage;
    private MoveSparkles moveSparkles;
    private CopyCat copyCat;

    protected override void Awake() {
        myImage = GetComponent<Image>();
        scoreManager = FindObjectOfType<ScoreManager>();
        moveSparkles = GetComponentInChildren<MoveSparkles>();
        copyCat = FindObjectOfType<CopyCat>();

        System.Array.Sort(medalDatas, (m1, m2) => {
            if (m1.scoreRequired >= m2.scoreRequired)
                return m1.scoreRequired;
            else
                return m2.scoreRequired;
            });
    }
    public void OnGameRestart() {
        myImage.sprite = emptySprite;
    }
    public void OnGameOver() {
        StartCoroutine(ShowMedal());
    }

    IEnumerator ShowMedal() {

        bool hasMedal = false;
        for (int i = medalDatas.Length - 1; i > -1; i--) {
            if (scoreManager.Score >= medalDatas[i].scoreRequired) {
                myImage.sprite = medalDatas[i].medalSprite;
                hasMedal = true;
                break;
            }
        }
        if (!hasMedal) {
            StartCoroutine(CrossFade(myImage, 0f, 0f));
        }
        else {
            yield return StartCoroutine(CrossFade(myImage, myImage.color.a, 1f, null, 2f));
            moveSparkles?.Init();
            copyCat.eventManager.NotifyListeners_OnMedalAwarded();
        }

        yield return null;

    }
}

