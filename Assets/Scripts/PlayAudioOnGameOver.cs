using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioOnGameOver : MonoBehaviour, IOnGameOver, IOnUpdate {
    [SerializeField]
    private AudioClip gameOverClip = null;
    [SerializeField]
    private AudioClip hitClip = null;
    public float delay = 0f; 
    private static AudioSource thisAudioSource;
    private static AudioClip gameOverClipStatic; 
    float t = 0;

    public float TimeSinceUpdating { get; set; }
    public bool RemoveThisFromUpdater { get; set; }

    void Awake() {
        thisAudioSource = GetComponent<AudioSource>();
        gameOverClipStatic = gameOverClip;
    }
    public void OnGameOver() {   
        CopyCat.Updater.AddToUpdate(this);
    }

    public void OnUpdate() {
        t += Time.deltaTime;
        if (t < delay) {
            return;
        }
        thisAudioSource.PlayOneShot(hitClip);
        t = 0;
        RemoveThisFromUpdater = true;
    }

    public static void PlayFallSound() {
        thisAudioSource.PlayOneShot(gameOverClipStatic);
    }
}
