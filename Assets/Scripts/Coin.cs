using UnityEngine;

public class Coin : MonoBehaviour {
    public ParticleSystem coinParticleSystem;
    SpriteRenderer sr;
    Collider2D col;

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        coinParticleSystem.transform.localPosition = Vector3.zero;
        coinParticleSystem.Emit(7);
        sr.enabled = false;
        col.enabled = false;
    }
    public void Reset() {
        sr.enabled = true;
        col.enabled = true;
    }
}
