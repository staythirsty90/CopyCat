using UnityEngine;

public class UIMoveUpAndDownLoopOnGameOver : UIMonoBehaviour, IOnGameRestart, IOnUpdate, IOnGameOver {
    public float upUnits;
    public float time = 1f;
    protected RectTransform thisRectTransform;
    protected float currentLerpTime;
    protected float lerpPercent;
    public bool zeroOutX = false;
    protected Vector2 startPosition, endPosition;

    public float TimeSinceUpdating { get; set; }
    public bool RemoveThisFromUpdater { get; set; }

    protected override void Awake() {
        thisRectTransform = GetComponent<RectTransform>();

        if (zeroOutX) {
            startPosition = new Vector2(0, thisRectTransform.anchoredPosition.y);
        }
        else {
            startPosition = thisRectTransform.anchoredPosition;
        }

        endPosition = startPosition;
        endPosition.y += upUnits;
    }

    public virtual void OnGameRestart() {
        lerpPercent = 0;
        currentLerpTime = 0;
        RemoveThisFromUpdater = true;
    }

    public void OnUpdate() {
        lerpPercent = currentLerpTime / time;
        thisRectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, lerpPercent);
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime > time) {
            currentLerpTime = 0f;
            Vector2 temp = startPosition;
            startPosition = endPosition;
            endPosition = temp;
        }
    }

    public void OnGameOver() {
        CopyCat.Updater.AddToUpdate(this);
    }
}
