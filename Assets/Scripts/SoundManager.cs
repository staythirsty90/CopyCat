using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour, IOnMedalAwarded {
    private static AudioSource thisAudioSource;
    [SerializeField]
    private AudioClip medalAward = null;
    [SerializeField]
    private Slider audioSlider = null;
    [SerializeField]
    private Text volumeText = null;

    void Awake () {
        thisAudioSource = GetComponent<AudioSource> ();
        float volume = PlayerPrefs.GetFloat("soundvolume", audioSlider.maxValue);
        audioSlider.value = volume * audioSlider.maxValue;
    }

    public void OnValueChanged(float value) {
        PlayerPrefs.SetFloat("soundvolume", value / audioSlider.maxValue);
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