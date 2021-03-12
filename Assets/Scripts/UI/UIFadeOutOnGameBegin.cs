public class UIFadeOutOnGameBegin : UIMonoBehaviour, IOnGameBegin {
    public void OnGameBegin() {
        StartCoroutine(CrossFade(thisImage, thisImage.color.a, 0f, fadeTime));
    }
}
