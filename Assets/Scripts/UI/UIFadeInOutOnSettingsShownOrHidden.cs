public class UIFadeInOutOnSettingsShownOrHidden : UIMonoBehaviour {
    public float endAlpha = 0.5f;

    void OnEnable() {
        Settings.OnSettingsShown += OnSettingsShown;
        Settings.OnSettingsHidden += OnSettingsHidden;
    }

    void OnDisable() {
        Settings.OnSettingsShown -= OnSettingsShown;
        Settings.OnSettingsHidden -= OnSettingsHidden;
    }

    void OnSettingsHidden() {
        StartCoroutine(CrossFade(thisImage, 0, 0, 0));
    }

    void OnSettingsShown() {
        StartCoroutine(CrossFade(thisImage, thisImage.color.a, endAlpha, 0f));
    }
}
