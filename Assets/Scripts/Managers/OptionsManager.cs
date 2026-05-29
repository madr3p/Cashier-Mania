using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [Header("Sliders")]
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("Toggles")]
    public Toggle musicToggle;
    public Toggle sfxToggle;

    private bool musicMuted = false;
    private bool sfxMuted = false;

    void Start()
    {
        // Load saved values
        float musicVol = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float sfxVol = PlayerPrefs.GetFloat("SFXVolume", 1f);

        musicMuted = PlayerPrefs.GetInt("MusicMuted", 0) == 1;
        sfxMuted = PlayerPrefs.GetInt("SFXMuted", 0) == 1;

        // Set sliders WITHOUT triggering listeners
        musicSlider.SetValueWithoutNotify(musicVol);
        sfxSlider.SetValueWithoutNotify(sfxVol);

        // Toggle ON means sound enabled
        musicToggle.SetIsOnWithoutNotify(!musicMuted);
        sfxToggle.SetIsOnWithoutNotify(!sfxMuted);

        // Apply loaded settings
        ApplyMusicSettings();
        ApplySFXSettings();

        // Add listeners
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        musicToggle.onValueChanged.AddListener(ToggleMusic);
        sfxToggle.onValueChanged.AddListener(ToggleSFX);
    }

    // ================= MUSIC =================

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();

        ApplyMusicSettings();

        Debug.Log("Music Volume Changed: " + volume);
    }

    public void ToggleMusic(bool isOn)
    {
        musicMuted = !isOn;

        PlayerPrefs.SetInt("MusicMuted", musicMuted ? 1 : 0);
        PlayerPrefs.Save();

        ApplyMusicSettings();

        Debug.Log("Music Toggle: " + isOn);
    }

    void ApplyMusicSettings()
    {
        if (musicMuted)
        {
            SoundManager.Instance.SetMusicVolume(0f);
        }
        else
        {
            SoundManager.Instance.SetMusicVolume(musicSlider.value);
        }
    }

    // ================= SFX =================

    public void SetSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();

        ApplySFXSettings();

        Debug.Log("SFX Volume Changed: " + volume);
    }

    public void ToggleSFX(bool isOn)
    {
        sfxMuted = !isOn;

        PlayerPrefs.SetInt("SFXMuted", sfxMuted ? 1 : 0);
        PlayerPrefs.Save();

        ApplySFXSettings();

        Debug.Log("SFX Toggle: " + isOn);
    }

    void ApplySFXSettings()
    {
        if (sfxMuted)
        {
            SoundManager.Instance.SetSFXVolume(0f);
        }
        else
        {
            SoundManager.Instance.SetSFXVolume(sfxSlider.value);
        }
    }
}