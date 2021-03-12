using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioOnScore : MonoBehaviour, IOnUpdate, IOnScorePoint {
    [SerializeField]
    private AudioClip scoreClip = null;
    private AudioSource thisAudioSource;
    public float delay;
    float t = 0;

    public float TimeSinceUpdating { get; set; }
    public bool RemoveThisFromUpdater { get; set; }

    void Awake() {
        thisAudioSource = GetComponent<AudioSource>();
    }

    public void OnScorePoint(int score) {
        if (score == 0)
            return;
        CopyCat.Updater.AddToUpdate(this);
    }

    public void OnUpdate() {
        t += Time.deltaTime;
        if (t < delay) {
            return;
        }
        thisAudioSource.PlayOneShot(scoreClip);
        t = 0;
        RemoveThisFromUpdater = true;
    }
}
