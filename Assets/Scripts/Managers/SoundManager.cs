using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Music")]
    public AudioClip themeSong;
    public AudioClip gameplaySong;

    [Header("SFX")]
    public AudioClip click;
    public AudioClip scan;
    public AudioClip nextCustomer;
    public AudioClip levelComplete;
    public AudioClip levelLose;

    [Header("Transition")]
    public float crossfadeSpeed = 2f;

    private AudioClip currentMusic;

    float musicVolume = 1f;
    float sfxVolume = 1f;

    bool musicEnabled = true;
    bool sfxEnabled = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        LoadSettings();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        UpdateVolumes();
    }

    void OnSceneLoaded(
        Scene scene,
        LoadSceneMode mode
    )
    {
        string sceneName =
            scene.name;

        if (
            sceneName == "MainMenu"
            ||
            sceneName == "Options"
            ||
            sceneName == "Credits"
            ||
            sceneName == "Tutorial"
            ||
            sceneName == "LevelSelection"
        )
        {
            ChangeMusic(themeSong);
        }

        else if (
            sceneName == "LevelEasy"
            ||
            sceneName == "LevelMedium"
            ||
            sceneName == "LevelHard"
        )
        {
            ChangeMusic(gameplaySong);
        }
    }

    //--------------------------------
    // MUSIC
    //--------------------------------

    public void ChangeMusic(
        AudioClip newMusic
    )
    {
        if (currentMusic == newMusic)
            return;

        currentMusic = newMusic;

        StartCoroutine(
            CrossFade(newMusic)
        );
    }

    IEnumerator CrossFade(
        AudioClip newMusic
    )
    {
        while (musicSource.volume > 0)
        {
            musicSource.volume -=
                Time.deltaTime
                * crossfadeSpeed;

            yield return null;
        }

        musicSource.Stop();

        musicSource.clip = newMusic;

        musicSource.Play();

        float targetVolume =
            musicEnabled
            ? musicVolume
            : 0f;

        while (
            musicSource.volume
            < targetVolume
        )
        {
            musicSource.volume +=
                Time.deltaTime
                * crossfadeSpeed;

            yield return null;
        }

        musicSource.volume =
            targetVolume;
    }

    //--------------------------------
    // SFX
    //--------------------------------

    public void PlayClick()
    {
        PlaySFX(click);
    }

    public void PlayScan()
    {
        PlaySFX(scan);
    }

    public void PlayNextCustomer()
    {
        PlaySFX(nextCustomer);
    }

    public void PlayLevelComplete()
    {
        PlaySFX(levelComplete);
    }

    public void PlayLevelLose()
    {
        PlaySFX(levelLose);
    }

    void PlaySFX(
        AudioClip clip
    )
    {
        if (
            !sfxEnabled
            ||
            clip == null
        )
            return;

        sfxSource.PlayOneShot(clip);
    }

    //--------------------------------
    // SETTINGS
    //--------------------------------

    public void SetMusicVolume(
        float value
    )
    {
        musicVolume = value;

        PlayerPrefs.SetFloat(
            "MusicVolume",
            value
        );

        PlayerPrefs.Save();

        UpdateVolumes();

        Debug.Log(
            "Music Volume Changed: "
            + value
        );
    }

    public void SetSFXVolume(
        float value
    )
    {
        sfxVolume = value;

        PlayerPrefs.SetFloat(
            "SFXVolume",
            value
        );

        PlayerPrefs.Save();

        UpdateVolumes();

        Debug.Log(
            "SFX Volume Changed: "
            + value
        );
    }

    public void ToggleMusic(
        bool state
    )
    {
        musicEnabled = state;

        PlayerPrefs.SetInt(
            "MusicEnabled",
            state ? 1 : 0
        );

        PlayerPrefs.Save();

        UpdateVolumes();
    }

    public void ToggleSFX(
        bool state
    )
    {
        sfxEnabled = state;

        PlayerPrefs.SetInt(
            "SFXEnabled",
            state ? 1 : 0
        );

        PlayerPrefs.Save();

        UpdateVolumes();
    }

    void UpdateVolumes()
    {
        if (musicSource != null)
        {
            musicSource.volume =
                musicEnabled
                ? musicVolume
                : 0f;

            musicSource.mute =
                !musicEnabled;
        }

        if (sfxSource != null)
        {
            sfxSource.volume =
                sfxEnabled
                ? sfxVolume
                : 0f;

            sfxSource.mute =
                !sfxEnabled;
        }
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

    //--------------------------------
    // DEBUG RESET
    //--------------------------------

    [ContextMenu("Reset Audio Save")]
    void ResetAudioSave()
    {
        PlayerPrefs.DeleteKey("MusicVolume");
        PlayerPrefs.DeleteKey("SFXVolume");
        PlayerPrefs.DeleteKey("MusicEnabled");
        PlayerPrefs.DeleteKey("SFXEnabled");

        PlayerPrefs.Save();

        Debug.Log("Audio save reset.");
    }
}