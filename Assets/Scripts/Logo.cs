using UnityEngine;

public class Logo : MonoBehaviour {
    private RectTransform thisRectTransform;

    void Awake() {
        thisRectTransform = GetComponent<RectTransform>();

        if (Screen.orientation == ScreenOrientation.Landscape ||
            Screen.orientation == ScreenOrientation.LandscapeLeft ||
            Screen.orientation == ScreenOrientation.LandscapeRight) {
            thisRectTransform.localScale = Vector3.one;
        }
    }
}
