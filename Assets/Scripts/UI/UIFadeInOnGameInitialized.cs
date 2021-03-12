public class UIFadeInOnGameInitialized : UIMonoBehaviour, IOnGameInitialized {

    public void OnGameInitialized() {
        StartCoroutine(FadeIn());
    }
}
