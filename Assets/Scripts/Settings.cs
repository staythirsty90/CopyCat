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
            copyCat.EventManager.NotifyListeners_OnSettingsClose();
        }
        else {
            copyCat.EventManager.NotifyListeners_OnSettingsOpen();
        }

        gameObject.SetActive(!isEnabled);
    }
}
