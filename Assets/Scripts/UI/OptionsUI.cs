using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    public Toggle musicToggle;
    public Toggle sfxToggle;

    void Start()
    {
        musicSlider.value =
            SoundManager.Instance
            .GetMusicVolume();

        sfxSlider.value =
            SoundManager.Instance
            .GetSFXVolume();

        musicToggle.isOn =
            SoundManager.Instance
            .GetMusicEnabled();

        sfxToggle.isOn =
            SoundManager.Instance
            .GetSFXEnabled();
    }

    public void MusicVolume(float value)
    {
        SoundManager.Instance
            .SetMusicVolume(value);
    }

    public void SFXVolume(float value)
    {
        SoundManager.Instance
            .SetSFXVolume(value);
    }

    public void MusicToggle(bool value)
    {
        SoundManager.Instance
            .SetMusicEnabled(value);
    }

    public void SFXToggle(bool value)
    {
        SoundManager.Instance
            .SetSFXEnabled(value);
    }
}