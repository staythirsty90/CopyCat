
public class UIFadeOutOnGameRestart : UIMonoBehaviour, IOnGameRestart {
    public void OnGameRestart() {
        StartCoroutine(FadeOut());
    }
}
