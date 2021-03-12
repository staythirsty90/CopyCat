using UnityEngine;
using UnityEngine.UI;

public class FPSTest : MonoBehaviour {
    public int fps = 60;
    public int xRes;
    public int yRes;
    private Text text;

    void Awake() {
        text = GetComponent<Text>();

        if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
            Screen.SetResolution(xRes, yRes, true);
        }
        else if (Screen.orientation == ScreenOrientation.Landscape || Screen.orientation == ScreenOrientation.LandscapeLeft
            || Screen.orientation == ScreenOrientation.LandscapeRight) {
            Screen.SetResolution(yRes, xRes, true);
        }
        //Screen.SetResolution(480, 800, true);
        // text.text = Screen.orientation.ToString();

    }
    // Use this for initialization
    void Start() {
        Application.targetFrameRate = fps;

    }

    //void Update()
    //{
    //    // text.text = Screen.currentResolution.ToString();
    //    text.text = Screen.orientation.ToString();
    //}

}
