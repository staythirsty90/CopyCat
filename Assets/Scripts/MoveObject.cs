using UnityEngine;

public class MoveObject : MonoBehaviour, IOnGameOver, IOnGamePlaying, IOnUpdate {
    private Transform thisTransform;
    public Vector2 moveDir = Vector2.left;
    float pixelX;
    Vector3 pos;

    public float TimeSinceUpdating { get; set; }
    public bool RemoveThisFromUpdater { get; set; }

    void Awake() {
        thisTransform = transform;
    }

    public void OnGamePlaying() {
        CopyCat.Updater.AddToUpdate(this);
    }

    public void OnGameOver() {
        RemoveThisFromUpdater = true;
    }

    public void OnUpdate() {
        pixelX = moveDir.x * Time.smoothDeltaTime;
        pos = new Vector3(thisTransform.localPosition.x + pixelX, thisTransform.localPosition.y, 0);
        thisTransform.localPosition = pos;
    }
}
