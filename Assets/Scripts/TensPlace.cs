using UnityEngine;
using UnityEngine.UI;

public class TensPlace : MonoBehaviour {
    private Image thisImage;

    void Awake() {
        thisImage = GetComponent<Image>();
    }

    void OnEnable() {
        //ScoreTextListener.OnScoreTensPlace += ScoreTextListener_OnScoreTensPlace;

    }
    void OnDisable() {
        //ScoreTextListener.OnScoreTensPlace -= ScoreTextListener_OnScoreTensPlace;
    }

    private void ScoreTextListener_OnScoreTensPlace() {
        thisImage.enabled = true;
        thisImage.color = new Color32(255, 255, 255, 255);
    }
}
