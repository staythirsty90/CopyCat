using UnityEngine;
using UnityEngine.UI;

public class MoveSparkles : MonoBehaviour, IOnGameRestart {
    public float X;
    public float Y;

    private RectTransform thisRectTransform;
    private Animator thisAnimator;
    private Image thisImage;

    void Awake() {
        thisRectTransform = GetComponent<RectTransform>();
        thisAnimator = GetComponent<Animator>();
        thisImage = GetComponent<Image>();
        thisAnimator.enabled = false;
        thisImage.enabled = false;
    }
    public void OnGameRestart() {
        thisAnimator.enabled = false;
        thisImage.enabled = false;
    }

    public void Init() {
        //Debug.Log("Wtf");
        thisAnimator.enabled = true;
        thisImage.enabled = true;
    }

    void MoveSparkle() {
        float maxX;
        float maxY;
        float x;
        float y;

        float angle = Random.Range(0, 360);
        maxX = Mathf.Cos(angle) * X;
        maxY = Mathf.Sin(angle) * Y;
        x = Random.Range(0, maxX);
        y = Random.Range(0, maxY);
        thisRectTransform.anchoredPosition = new Vector2(x, y);

    }

}
