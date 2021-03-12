using UnityEngine;
using UnityEngine.UI;

public class UIEnableButtonOnGameOver : MonoBehaviour, IOnGameOver {
    private Button thisButton;

    void Awake() {
        thisButton = GetComponent<Button>();
    }
    public void OnGameOver() {
        thisButton.interactable = true;
        thisButton.image.color = new Color32(255, 255, 255, 255);
    }
}
