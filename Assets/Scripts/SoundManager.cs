using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour, IOnMedalAwarded {
    static AudioSource thisAudioSource;
    [SerializeField] AudioClip medalAward = null;
    [SerializeField] Slider volumeSlider = null;
    [SerializeField] Text volumeText = null;

    void Awake () {
        thisAudioSource = GetComponent<AudioSource> ();
        float volume = PlayerPrefs.GetFloat("soundvolume", volumeSlider.maxValue);
        volumeSlider.value = volume * volumeSlider.maxValue;
    }

    public void OnValueChanged(float value) {
        PlayerPrefs.SetFloat("soundvolume", value / volumeSlider.maxValue);
        thisAudioSource.volume = Mathf.Log10(value) * 20;
        volumeText.text = GetVolumeText(value);
    }

    public static void PlayClip (AudioClip audioClip) {
        thisAudioSource.PlayOneShot (audioClip);
    }

    public void OnMedalAwarded() {
        thisAudioSource.PlayOneShot(medalAward);
    }

    private string GetVolumeText(float value) {
        const int divisor = 10;
        int value_as_int = System.Convert.ToInt32((value * divisor));
        return $"{value_as_int}%";
    }
}