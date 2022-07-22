using UnityEngine;

public class Coin : MonoBehaviour, IOnUpdate {
    public ParticleSystem coinParticleSystem;
    SpriteRenderer sr;
    Collider2D col;
    Vector3 originalScale;
    public float TimeSinceUpdating { get; set; }
    public bool RemoveThisFromUpdater { get; set; }

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        originalScale = transform.localScale;
    }
    private void OnTriggerEnter2D() {
        
        //sr.enabled = false;
        col.enabled = false;
        CopyCat.Updater.AddToUpdate(this);
    }
    public void Reset() {
        sr.enabled = true;
        col.enabled = true;
        transform.localScale = originalScale;
    }

    public void OnUpdate() {
        transform.localScale = Vector3.Slerp(transform.localScale, Vector3.zero, Time.deltaTime * 7);
        if(transform.localScale.x <= 0.05f) {
            RemoveThisFromUpdater = true;
            transform.localScale = Vector3.zero;
            coinParticleSystem.transform.localPosition = Vector3.zero;
            coinParticleSystem.Emit(10);
        }
    }
}
