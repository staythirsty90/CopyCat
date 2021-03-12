using UnityEngine;

public class Settings : MonoBehaviour {
    SoundSlider soundSlider;
    public static event System.Action OnSettingsShown, OnSettingsHidden;

    void Awake() {
        soundSlider = GetComponentInChildren<SoundSlider>();
    }

    void Start() {
        soundSlider.Init();
        HideSettings();
    }

    public void ShowSettings() {
        bool isEnabled = gameObject.activeInHierarchy;

        if (!isEnabled) {
            OnSettingsShown?.Invoke();
        }
        else {
            OnSettingsHidden?.Invoke();
        }

        gameObject.SetActive(!isEnabled);
    }

    public void HideSettings() {
        gameObject.SetActive(false);
    }
}
