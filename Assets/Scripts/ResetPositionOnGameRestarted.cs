using UnityEngine;

public class ResetPositionOnGameRestarted : MonoBehaviour, IOnGameRestarted {
    private Transform thisTransform;
    private Vector3 originalPosition;

    void Awake() {
        thisTransform = transform;
        originalPosition = thisTransform.localPosition;
    }

    public void OnGameRestarted() {
        thisTransform.localPosition = originalPosition;
    }
}

