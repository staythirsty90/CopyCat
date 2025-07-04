using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RestartGameButton : UIMonoBehaviour, IOnGameOver, IOnGameRestart {
    public float fadeInTime = 0.3f;
    public float restartGameDelay = 1f;
    public Vector2 endPosition;

    [SerializeField] AudioClip restartAudio;
    [SerializeField] Image blackFadeImage;

    Vector2 originalPosition;
    Button thisButton;
    bool didClickRestart;
    CopyCat copyCat;

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
        StartCoroutine(Delay());
    }

    IEnumerator Delay() {
        var t = 0f;
        while (t <= delay) {
            t += Time.deltaTime;
            yield return null;
        }

        thisImage.rectTransform.anchoredPosition = endPosition;
        StartCoroutine(This_FadeIn(thisImage, false));
    }
    
    public void Restart() {
        if (!didClickRestart) {
            didClickRestart = true;
            SoundManager.PlayClip(restartAudio);
            StartCoroutine(RestartGame());
        }
    }

    IEnumerator RestartGame() {
        var t = 0f;
        blackFadeImage.rectTransform.anchoredPosition = Vector3.zero;
        yield return StartCoroutine(This_FadeOut(thisImage));
        thisImage.rectTransform.anchoredPosition = originalPosition;
        yield return StartCoroutine(This_FadeIn(blackFadeImage, restartAfter: true));
        while (t < restartGameDelay) {
            yield return null;
            t += Time.deltaTime;
        }
        StartCoroutine(This_FadeOut(blackFadeImage));
        didClickRestart = false;
    }

    IEnumerator This_FadeIn(MaskableGraphic graphic, bool restartAfter) {
        yield return StartCoroutine(CrossFade(graphic, graphic.color.a, delay));
        if (restartAfter) {
            var t = 0f;
            while (t < restartGameDelay) {
                yield return null;
                t += Time.deltaTime;
            }
            copyCat.RestartGame();
            yield return StartCoroutine(This_FadeOut(graphic));
            copyCat.BeginGamePlay();
        }
        else {
            thisButton.interactable = true;
        }
    }

    IEnumerator This_FadeOut(MaskableGraphic thisImage) {
        var t = 0f;
        while (t < restartGameDelay) {
            yield return null;
            t += Time.deltaTime;
        }
        yield return StartCoroutine(CrossFade(thisImage, thisImage.color.a, 0f));
    }
}