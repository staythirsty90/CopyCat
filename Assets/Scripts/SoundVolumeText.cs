using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeText : MonoBehaviour {
    [SerializeField]
    private Image onesPlace = null;
    [SerializeField]
    private Image tensPlace = null;
    [SerializeField]
    private Image hundredsPlace = null;
    [SerializeField]
    private GameDigits gameDigits = null;

    void OnEnable() {
        SoundSlider.OnSoundSliderChanged += SoundSlider_OnSoundSliderChanged;
    }

    void OnDisable() {
        SoundSlider.OnSoundSliderChanged -= SoundSlider_OnSoundSliderChanged;
    }

    private void SoundSlider_OnSoundSliderChanged(float value) {
        const int divisor = 10;
        int value_as_int = System.Convert.ToInt32((value * divisor * divisor));
        int place = (value_as_int * divisor) % divisor;
        onesPlace.sprite = gameDigits.GameDigit[place];
        value_as_int /= divisor;
        place = value_as_int % divisor;
        tensPlace.sprite = gameDigits.GameDigit[place];
        value_as_int /= divisor;
        place = value_as_int % divisor;
        hundredsPlace.sprite = gameDigits.GameDigit[place];

        if (value == 0) {
            hundredsPlace.enabled = false;
            tensPlace.enabled = false;
        }
        else if (value >= 1) {
            hundredsPlace.enabled = true;
            tensPlace.enabled = true;
        }
        else {
            hundredsPlace.enabled = false;
            tensPlace.enabled = true;
        }
    }
}
