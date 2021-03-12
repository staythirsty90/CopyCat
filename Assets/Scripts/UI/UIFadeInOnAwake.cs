public class UIFadeInOnAwake : UIMonoBehaviour {
    
    protected override void Awake() {
        base.Awake();
        StartCoroutine(FadeIn());
    }
}
