using UnityEngine;
using UnityEngine.UI;

public class HundredsPlace : MonoBehaviour {
    private Image thisImage;

    void Awake() {
        thisImage = GetComponent<Image>();
    }

    void OnEnable() {
        //ScoreTextListener.OnScoreHundredsPlace += OnScoreHundredsPlace;
    }

    void OnDisable() {
        //ScoreTextListener.OnScoreHundredsPlace -= OnScoreHundredsPlace;
    }

    private void OnScoreHundredsPlace() {
        Debug.Log("ON SCORE HUNDREDS PLACE");
        thisImage.enabled = true;
        thisImage.color = new Color32(255, 255, 255, 255);
    }
}
