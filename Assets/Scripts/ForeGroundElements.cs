using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class ForeGroundElements : MonoBehaviour, IOnGameRestart, IOnUpdate {
    public float maxX = -6;
    public float xOffset = 3;
    private Transform thisTransform;
    private static List<Transform> elements = new List<Transform>(3);
    private static bool didSort = false;
    private static Transform closestElement;
    private static Transform originalClosestElement;

    public float TimeSinceUpdating { get; set; }
    public bool RemoveThisFromUpdater { get; set; }

    void Awake() {
        thisTransform = transform;
        elements.Add(thisTransform);
    }

    void Start() {
        if (!didSort) {
            elements = elements.OrderByDescending(element => element.position.x).ToList();
            didSort = true;
            closestElement = elements.First();
            originalClosestElement = closestElement;
        }
    }

    public void OnGameRestart() {
        closestElement = originalClosestElement;
        RemoveThisFromUpdater = true;
    }
    void ResetPosition() {
        thisTransform.position = new Vector2(closestElement.position.x + xOffset, thisTransform.position.y);
        closestElement = thisTransform;
    }
    public void OnUpdate() {
        if (thisTransform.position.x <= maxX) {
            ResetPosition();
        }
    }
}
