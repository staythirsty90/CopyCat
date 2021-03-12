using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KillOnCollide : MonoBehaviour, IOnUpdate, IOnGameRestarted {
    private Rigidbody2D thisRigidbody;
    private Transform thisTransform;
    private bool didDie = false;
    public float TimeSinceUpdating { get; set; } 
    public bool RemoveThisFromUpdater { get; set; }
    CopyCat copyCat;
    void Awake() {
        thisRigidbody = GetComponent<Rigidbody2D>();
        thisTransform = transform;
        copyCat = FindObjectOfType<CopyCat>();
    }

    public void OnGameRestarted() {
        thisRigidbody.angularVelocity = 0;
        thisRigidbody.velocity = Vector2.zero;
        thisTransform.localRotation = Quaternion.Euler(Vector3.zero);
        thisRigidbody.isKinematic = false;
        didDie = false;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (didDie) {
            return;
        }
        UnityEngine.Profiling.Profiler.BeginSample("KILL");

        if (other.name.Contains("Pipe")) {
            didDie = true;
            Kill();
        }
        UnityEngine.Profiling.Profiler.EndSample();
    }

    void Kill() {
        copyCat.EndGame();
        CopyCat.Updater.AddToUpdate(this);
    }

    public void OnUpdate() {
        if (TimeSinceUpdating >= 0.25f) {
            PlayAudioOnGameOver.PlayFallSound();
            RemoveThisFromUpdater = true;
        }
    }
}
