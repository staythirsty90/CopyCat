using UnityEngine;

public class PlaySoundListener : MonoBehaviour {

    private AudioSource thisAudioSource;

    void Awake() {
        thisAudioSource = GetComponent<AudioSource>();
    }

    void OnEnable() {
        UIMonoBehaviour.PlayAudio += UIPlayAudioOnFadeInBegin_PlayAudio;
    }

    void OnDisable() {
        UIMonoBehaviour.PlayAudio -= UIPlayAudioOnFadeInBegin_PlayAudio;
    }

    private void UIPlayAudioOnFadeInBegin_PlayAudio(AudioClip clip) {
        thisAudioSource.PlayOneShot(clip);
    }
}
