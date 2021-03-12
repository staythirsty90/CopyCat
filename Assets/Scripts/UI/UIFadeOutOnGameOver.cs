public class UIFadeOutOnGameOver : UIMonoBehaviour, IOnGameOver {
    public void OnGameOver() {
        StartCoroutine(FadeOut());
    }
}
