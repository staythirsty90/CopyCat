using UnityEngine;
using UnityEngine.UI;

public class UIHideOnSettingsShown : MonoBehaviour {
    private Image thisImage;
    //private bool wasEnabled = false;

    void Awake() {
        thisImage = GetComponent<Image>();
    }

    void OnEnable() {
        Settings.OnSettingsShown += Settings_OnSettingsShown;
        Settings.OnSettingsHidden += Settings_OnSettingsHidden;
    }

    void OnDisable() {
        Settings.OnSettingsShown -= Settings_OnSettingsShown;
        Settings.OnSettingsHidden -= Settings_OnSettingsHidden;
    }

    private void Settings_OnSettingsHidden() {
        thisImage.enabled = true;
    }


    private void Settings_OnSettingsShown() {
        thisImage.enabled = false;
    }
}
