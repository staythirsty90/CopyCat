using UnityEngine;

public class Settings : MonoBehaviour {
    CopyCat copyCat;
    private void Awake() {
        copyCat = FindObjectOfType<CopyCat>();    
    }
    void Start() {
        gameObject.SetActive(false);
    }

    public void ShowSettings() {
        bool isEnabled = gameObject.activeInHierarchy;

        if (isEnabled) {
            copyCat.eventManager.NotifyListeners_OnSettingsClose();
        }
        else {
            copyCat.eventManager.NotifyListeners_OnSettingsOpen();
        }

        gameObject.SetActive(!isEnabled);
    }
}
