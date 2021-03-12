public class UIFadeInOnGameOver : UIMonoBehaviour, IOnGameOver {
    public void OnGameOver() {
        StartCoroutine(FadeIn());
    }
}
