using UnityEngine;
using UnityEngine.UI;

public class UIToggleVisibilityOnSettingsOpenClose : MonoBehaviour, IOnSettingsOpen, IOnSettingsClose {
    private Image thisImage;
    void Awake() {
        thisImage = GetComponent<Image>();
    }
    public void OnSettingsOpen() {
        thisImage.enabled = false;
    }

    public void OnSettingsClose() {
        thisImage.enabled = true;
    }
}
