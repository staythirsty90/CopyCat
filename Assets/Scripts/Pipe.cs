using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Pipe : MonoBehaviour, IOnGameBegin, IOnGameRestart, IOnUpdate, IOnGamePlaying, IOnGameOver {
    Coin coin;
    private Transform thisTransform;
    [SerializeField]
    private float minYSpawnOffset = -5.5f;
    [SerializeField]
    private float maxYSpawnOffset = 1;
    private static Transform lastTransform;
    public float maxX = -6;
    public float xOffset = 3;
    private static Transform originalLastTransform;

    public float TimeSinceUpdating { get; set; }
    public bool RemoveThisFromUpdater { get; set; }

    void Awake() {
        thisTransform = transform;
        coin = GetComponentInChildren<Coin>();
    }
    void Start() {
        originalLastTransform = PipeManager.GetLastPipeTransform();
        lastTransform = originalLastTransform;
    }
    public void OnGameRestart() {
        lastTransform = originalLastTransform;
    }
    void ResetPosition() {
        thisTransform.localPosition = new Vector2(lastTransform.localPosition.x + xOffset, 0f);
        lastTransform = thisTransform;
        OnGameBegin();
    }
    public void OnGameBegin() {
        float ySpawnOffset = Random.Range(minYSpawnOffset, maxYSpawnOffset);
        thisTransform.localPosition = new Vector2(thisTransform.localPosition.x, ySpawnOffset);
        if (coin) {
            coin.Reset();
        }
    }

    public void OnUpdate() {
        if (thisTransform.position.x <= maxX) {
            ResetPosition();
        }
    }

    public void OnGamePlaying() {
        CopyCat.Updater.AddToUpdate(this);
    }

    public void OnGameOver() {
        RemoveThisFromUpdater = true;
    }
}
