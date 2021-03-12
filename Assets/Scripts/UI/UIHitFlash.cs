using UnityEngine;

public class UIHitFlash : UIMonoBehaviour, IOnGameOver {
    [Range(0, 1f), SerializeField]
    private float alphaIntensity = 1f;
    public void OnGameOver() {
        StartCoroutine(CrossFadeInAndOut(thisImage, 0f, alphaIntensity, fadeTime));
    }
}
