public class UIFadeOutOnAwake : UIMonoBehaviour {
    protected override void Awake() {
        base.Awake();
        StartCoroutine(FadeOut());
    }
}
