using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIMonoBehaviour : MonoBehaviour {

    public static event System.Action<AudioClip> PlayAudio;
    [SerializeField]
    protected AudioClip audioClip;
    [SerializeField]
    protected float fadeTime;
    [SerializeField]
    protected float delay;

    protected MaskableGraphic thisImage;

    protected virtual void Awake() {
        thisImage = GetComponent<MaskableGraphic>();
    }

    public IEnumerator FadeOut() {
        float t = 0;
        while (t < delay) {
            yield return null;
            t += Time.deltaTime;
        }
        StartCoroutine(CrossFade(thisImage, thisImage.color.a, 0f, fadeTime));
    }

    public IEnumerator FadeIn() {
        float t = 0;
        while (t < delay) {
            yield return null;
            t += Time.deltaTime;
        }
        StartCoroutine(CrossFade(thisImage, thisImage.color.a, 1f, fadeTime));
    }

    public IEnumerator CrossFade(MaskableGraphic image, float startAlpha, float endAplha, float time, AudioClip audioClip, float delay) {
        float t = 0;

        while (t <= delay) {
            t += Time.deltaTime;
            yield return null;
        }

        if (audioClip) {
            PlayAudio?.Invoke(audioClip);
        }

        yield return StartCoroutine(Fade(image, startAlpha, endAplha, time, false));
    }

    public IEnumerator CrossFade(MaskableGraphic image, float startAlpha, float endAlpha, float duration) {
        if (audioClip) {
            PlayAudio?.Invoke(audioClip);
        }
        yield return StartCoroutine(Fade(image, startAlpha, endAlpha, duration, false));
    }

    public IEnumerator CrossFadeInAndOut(MaskableGraphic image, float startAlpha, float endAplha, float time) {
        yield return StartCoroutine(Fade(image, startAlpha, endAplha, time, true));
    }

    protected IEnumerator Fade(MaskableGraphic image, float startAlpha, float endAplha, float duration, bool fadeOutAfter) {
        if (!image.enabled) {
            image.enabled = true;
        }
        float lerpDuration = duration;
        float currentLerpDuration = 0f;
        float t = currentLerpDuration / lerpDuration;

        Color startColor;
        Color endColor;

        startColor = image.color;
        endColor = startColor;

        startColor.a = startAlpha;
        endColor.a = endAplha;

        image.color = startColor;

        while (t < 1f) {
            t = currentLerpDuration / lerpDuration;
            image.color = Color.Lerp(startColor, endColor, t);
            currentLerpDuration += Time.deltaTime;
            //Debug.Log($"T: {t}, Alpha:{image.color.a}, image:{image.name}");
            yield return null;
        }

        if (fadeOutAfter) {
            currentLerpDuration = 0f;
            t = currentLerpDuration / lerpDuration;

            startColor.a = endAplha;
            endColor.a = startAlpha;

            while (t < 1f) {
                t = currentLerpDuration / lerpDuration;
                startColor = Color.Lerp(startColor, endColor, t);
                image.color = startColor;
                currentLerpDuration += Time.deltaTime;
                yield return null;
            }
        }

        startColor = endColor;
        image.color = startColor;

        if (image.color.a <= 0) {
            image.enabled = false;
        }
    }
}
