public class UIFadeOutOnGameInitialized : UIMonoBehaviour, IOnGameInitialized {
    public void OnGameInitialized() {
        StartCoroutine(FadeOut());
    }
}
