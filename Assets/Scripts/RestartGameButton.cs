using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RestartGameButton : UIMonoBehaviour, IOnGameOver, IOnGameRestart {
    [SerializeField]
    private AudioClip restartAudio = null;
    public float fadeInTime = 0.3f;
    public float restartGameDelay = 1f;
    [SerializeField]
    private Image blackFadeImage = null;
    public Vector2 endPosition;
    private Vector2 originalPosition;
    private Button thisButton;
    private bool didClickRestart = false;
    private CopyCat copyCat;

    protected override void Awake() {
        base.Awake();
        thisButton = GetComponent<Button>();
        originalPosition = thisImage.rectTransform.anchoredPosition;
        copyCat = FindObjectOfType<CopyCat>();
    }

    public void OnGameRestart() {
        thisButton.interactable = false;
        thisImage.enabled = false;
        didClickRestart = false;
    }
    public void OnGameOver() {
        // TODO FIX IT ALL
        // thisImage.rectTransform.anchoredPosition = endPosition;
        // thisImage.enabled = true;
        // thisButton.interactable = true;
        // thisImage.color = new Color32(255, 255, 255, 255);
        // CopyCat.OnUpdate += restartGameHandler;
        StartCoroutine(Delay());
        //CopyCat.Updater.AddToUpdate(this);
    }


    IEnumerator Delay() {
        float t = 0;

        while (t <= delay) {
            t += Time.deltaTime;
            yield return null;
        }
        thisImage.rectTransform.anchoredPosition = endPosition;
        StartCoroutine(FadeIn(thisImage, false));
    }

    IEnumerator FadeIn(MaskableGraphic thisImage, bool restartAfter) {
        yield return StartCoroutine(CrossFade(thisImage, thisImage.color.a, 1f, fadeInTime));
        if (restartAfter) {
            float t = 0;
            while (t < restartGameDelay) {
                yield return null;
                t += Time.deltaTime;
            }
            restart();
            yield return StartCoroutine(FadeOut(thisImage));
            copyCat.BeginGamePlay();
        }
        else {
            thisButton.interactable = true;
        }
    }

    public void Restart() {
        if (!didClickRestart) {
            didClickRestart = true;
            SoundManager.PlayClip(restartAudio);
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame() {
        float t = 0;
        blackFadeImage.rectTransform.anchoredPosition = Vector3.zero;
        yield return StartCoroutine(FadeOut(thisImage));
        thisImage.rectTransform.anchoredPosition = originalPosition;
        yield return StartCoroutine(FadeIn(blackFadeImage, restartAfter: true));
        while (t < restartGameDelay) {
            yield return null;
            t += Time.deltaTime;
        }
        StartCoroutine(FadeOut(blackFadeImage));
        didClickRestart = false;
    }

    IEnumerator FadeOut(MaskableGraphic thisImage) {
        float t = 0;
        while (t < restartGameDelay) {
            yield return null;
            t += Time.deltaTime;
        }
        yield return StartCoroutine(CrossFade(thisImage, thisImage.color.a, 0f, fadeInTime));
    }

    void restart() {
        copyCat.RestartGame();
    }
}
