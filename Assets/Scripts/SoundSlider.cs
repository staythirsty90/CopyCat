using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour {
    public static event System.Action<float> OnSoundSliderChanged;
    private Slider thisSlider;

    public void Init() {
        thisSlider = GetComponent<Slider>();
        float volume = PlayerPrefs.GetFloat("soundvolume", thisSlider.maxValue);
        thisSlider.value = volume * thisSlider.maxValue;
    }

    public void OnSliderChanged(float value) {
        OnSoundSliderChanged?.Invoke(value / thisSlider.maxValue);
        PlayerPrefs.SetFloat("soundvolume", value / thisSlider.maxValue);
    }
}
