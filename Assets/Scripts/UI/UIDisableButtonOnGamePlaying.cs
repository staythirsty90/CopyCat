using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UIDisableButtonOnGamePlaying : MonoBehaviour, IOnGamePlaying {
    Button thisButton;

    void Awake() {
        thisButton = GetComponent<Button>();
    }

    public void OnGamePlaying() {
        thisButton.interactable = false;
        thisButton.image.color = new Color32(255, 255, 255, 0);
    }
}