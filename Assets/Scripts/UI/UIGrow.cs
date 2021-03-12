using UnityEngine;

public abstract class UIGrow : UIMonoBehaviour, IOnGameRestart, IOnUpdate {
    public float time = 1f;
    protected RectTransform thisRectTransform;
    protected float currentLerpTime;
    protected float lerpPercent;
    protected float delayTimer = 0f;
    [SerializeField]
    protected Vector3 startScale, endScale;

    public float TimeSinceUpdating { get ; set ; }
    public bool RemoveThisFromUpdater { get ; set ; }

    protected override void Awake() {
        thisRectTransform = GetComponent<RectTransform>();
        startScale = thisRectTransform.localScale;
    }

    public void OnGameRestart() {
        delayTimer = 0f;
        currentLerpTime = 0f;
        thisRectTransform.localScale = startScale;
    }

    protected void OnUpdate() {
        if (delayTimer < delay) {
            delayTimer += Time.deltaTime;
            return;
        }
        lerpPercent = currentLerpTime / time;
        thisRectTransform.localScale = Vector3.Lerp(startScale, endScale, lerpPercent);
        currentLerpTime += Time.deltaTime;

        if (currentLerpTime > time) {
            OnGrowDone();
        }
    }

    protected virtual void OnGrowDone() {
        currentLerpTime = 0f;
        RemoveThisFromUpdater = true;
        thisRectTransform.localScale = endScale;
    }

    void IOnUpdate.OnUpdate() {
        OnUpdate();
    }
}
