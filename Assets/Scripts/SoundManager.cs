using UnityEngine;

public class SoundManager : MonoBehaviour {
    private static AudioSource thisAudioSource;

    void Awake () {
        thisAudioSource = GetComponent<AudioSource> ();
    }

    void OnEnable () {
        SoundSlider.OnSoundSliderChanged += SoundSlider_OnSoundSliderChanged;
        MedalReward.OnMedalRewarded += MedalReward_OnMedalRewarded;
    }

    private void MedalReward_OnMedalRewarded (AudioClip medalSound) {
        thisAudioSource.PlayOneShot (medalSound);
    }

    void OnDisable () {
        SoundSlider.OnSoundSliderChanged -= SoundSlider_OnSoundSliderChanged;
        MedalReward.OnMedalRewarded -= MedalReward_OnMedalRewarded;
    }

    private void SoundSlider_OnSoundSliderChanged (float value) {
        thisAudioSource.volume = value;
    }

    public static void PlayClip (AudioClip audioClip) {
        thisAudioSource.PlayOneShot (audioClip);
    }
}