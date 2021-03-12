using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MedalReward : UIMonoBehaviour, IOnGameOver, IOnGameRestart {
    public Sprite emptySprite;
    [SerializeField]
    private AudioClip medalSound = null;
    private Score score;


    public delegate void MedalRewardHandler(AudioClip medalSound);
    public static event MedalRewardHandler OnMedalRewarded;

    [System.Serializable]
    public struct MedalData {
        public Sprite medalSprite;
        public int scoreRequired;
    }

    public MedalData[] medalDatas;

    private Image myImage;

    protected override void Awake() {
        myImage = GetComponent<Image>();
        score = FindObjectOfType<Score>();
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
            if (score.GameScore >= medalDatas[i].scoreRequired) {
                myImage.sprite = medalDatas[i].medalSprite;
                hasMedal = true;
                break;
            }
        }
        if (!hasMedal) {
            // Debug.Log("fading out"); 
            StartCoroutine(CrossFade(myImage, 0f, 0f, 0f));
        }
        else {
            // Debug.Log("fading in");
            yield return StartCoroutine(CrossFade(myImage, myImage.color.a, 1f, .15f, null, 2f));
            if (OnMedalRewarded != null) {
                OnMedalRewarded(medalSound);
            }
        }

        yield return null;

    }
}

