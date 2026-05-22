using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Sounds")]
    public AudioClip backgroundMusic;
    public AudioClip buttonClick;
    public AudioClip scanSound;
    public AudioClip levelComplete;

    private float musicVolume = 1f;
    private float sfxVolume = 1f;

    private bool musicEnabled = true;
    private bool sfxEnabled = true;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadSettings();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        ApplySettings();
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        if(backgroundMusic == null)
            return;

        if(musicSource.clip != backgroundMusic)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
        }

        if(musicEnabled)
        {
            musicSource.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }

    public void PlayButtonClick()
    {
        if(sfxEnabled && buttonClick != null)
            sfxSource.PlayOneShot(buttonClick);
    }

    public void PlayScan()
    {
        if(sfxEnabled && scanSound != null)
            sfxSource.PlayOneShot(scanSound);
    }

    public void PlayLevelComplete()
    {
        if(sfxEnabled && levelComplete != null)
            sfxSource.PlayOneShot(levelComplete);
    }

    //-----------------------
    // OPTIONS FUNCTIONS
    //-----------------------

    public void SetMusicVolume(float value)
    {
        musicVolume = value;
        musicSource.volume = value;

        PlayerPrefs.SetFloat(
            "MusicVolume",
            value
        );
    }

    public void SetSFXVolume(float value)
    {
        sfxVolume = value;
        sfxSource.volume = value;

        PlayerPrefs.SetFloat(
            "SFXVolume",
            value
        );
    }

    public void SetMusicEnabled(bool enabled)
    {
        musicEnabled = enabled;

        if(enabled)
            musicSource.Play();
        else
            musicSource.Stop();

        PlayerPrefs.SetInt(
            "MusicEnabled",
            enabled ? 1 : 0
        );
    }

    public void SetSFXEnabled(bool enabled)
    {
        sfxEnabled = enabled;

        PlayerPrefs.SetInt(
            "SFXEnabled",
            enabled ? 1 : 0
        );
    }

    void LoadSettings()
    {
        musicVolume =
            PlayerPrefs.GetFloat(
                "MusicVolume",
                1f
            );

        sfxVolume =
            PlayerPrefs.GetFloat(
                "SFXVolume",
                1f
            );

        musicEnabled =
            PlayerPrefs.GetInt(
                "MusicEnabled",
                1
            ) == 1;

        sfxEnabled =
            PlayerPrefs.GetInt(
                "SFXEnabled",
                1
            ) == 1;
    }

    void ApplySettings()
    {
        musicSource.volume =
            musicVolume;

        sfxSource.volume =
            sfxVolume;

        if(!musicEnabled)
            musicSource.Stop();
    }

    // getters for UI
    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public float GetSFXVolume()
    {
        return sfxVolume;
    }

    public bool GetMusicEnabled()
    {
        return musicEnabled;
    }

    public bool GetSFXEnabled()
    {
        return sfxEnabled;
    }
}