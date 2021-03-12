public class UIFadeInOnGamePlaying : UIMonoBehaviour, IOnGamePlaying, IOnGameOver {
    public void OnGameOver() {
        StopAllCoroutines();
    }

    public void OnGamePlaying() {
        StartCoroutine(FadeIn());
    }
}
