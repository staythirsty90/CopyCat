using UnityEngine;

public class UIMoveUpAndDownOnceOnGameOver : UIMonoBehaviour, IOnGameOver, IOnGameRestart, IOnUpdate {
    public float upUnits;
    public float downUnits;
    public float timeToMoveUp = 1f;
    public float timeToMoveDown = 1f;
    private RectTransform thisRectTransform;
    private float currentLerpTime;
    private float lerpPercent;
    private float delayTime;
    private Vector2 originalPosition, endPosition;
    private bool movingUp = true;
    public Vector2 startPosition;

    public float TimeSinceUpdating { get; set; }
    public bool RemoveThisFromUpdater { get; set; }

    new void Awake() {
        thisRectTransform = GetComponent<RectTransform>();
        originalPosition = thisRectTransform.anchoredPosition;
        endPosition = originalPosition;
        endPosition.y += upUnits;
    }

    public void OnGameRestart() {
        thisRectTransform.anchoredPosition = originalPosition;
        currentLerpTime = 0;
        delayTime = 0;
        lerpPercent = 0;
    }

    public void OnGameOver() {
        thisRectTransform.anchoredPosition = startPosition;
        CopyCat.Updater.AddToUpdate(this);
    }

    void OnUpdate() {
        if (delayTime <= delay) {
            delayTime += Time.deltaTime;
            return;
        }

        if (movingUp) {
            thisRectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, lerpPercent);
            lerpPercent = currentLerpTime / timeToMoveUp;
            currentLerpTime += Time.deltaTime;

            if (currentLerpTime > timeToMoveUp) {
                currentLerpTime = 0f;
                movingUp = false;
                lerpPercent = 0;
                thisRectTransform.anchoredPosition = endPosition;
            }
        }
        else {
            lerpPercent = currentLerpTime / timeToMoveDown;
            thisRectTransform.anchoredPosition = Vector2.Lerp(endPosition, originalPosition, lerpPercent);
            currentLerpTime += Time.deltaTime;

            if (currentLerpTime > timeToMoveDown) {
                currentLerpTime = 0f;
                movingUp = true;
                RemoveThisFromUpdater = true;
                thisRectTransform.anchoredPosition = originalPosition;
            }
        }
    }

    void IOnUpdate.OnUpdate() {
        OnUpdate();
    }
}
