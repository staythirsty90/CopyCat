using UnityEngine;

public class PlayAudioOnJump : MonoBehaviour, IOnJump {
    [SerializeField]
    private AudioClip jumpClip = null;
    private AudioSource thisAudioSource;

    void Awake() {
        thisAudioSource = GetComponent<AudioSource>();
    }
    public void OnJump() {
        thisAudioSource.PlayOneShot(jumpClip);
    }
}
