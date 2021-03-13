using UnityEngine;

public class PlayAudioOnJump : MonoBehaviour, IOnPlayerJump {
    [SerializeField]
    private AudioClip jumpClip = null;
    private AudioSource thisAudioSource;

    void Awake() {
        thisAudioSource = GetComponent<AudioSource>();
    }
    public void OnPlayerJump() {
        thisAudioSource.PlayOneShot(jumpClip);
    }
}
