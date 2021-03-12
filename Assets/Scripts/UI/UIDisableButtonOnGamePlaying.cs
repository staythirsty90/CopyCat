using UnityEngine;
using UnityEngine.UI;

public class UIDisableButtonOnGamePlaying : MonoBehaviour, IOnGamePlaying {
    private Button thisButton;

    void Awake() {
        thisButton = GetComponent<Button>();
    }
    public void OnGamePlaying() {
        thisButton.interactable = false;
        thisButton.image.color = new Color32(255, 255, 255, 0);
    }
}
