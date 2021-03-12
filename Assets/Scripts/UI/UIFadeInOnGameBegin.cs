public class UIFadeInOnGameBegin : UIMonoBehaviour, IOnGameBegin {
    public void OnGameBegin() {
        StartCoroutine(FadeIn());
    }
}
