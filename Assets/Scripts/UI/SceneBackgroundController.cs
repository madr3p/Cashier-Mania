using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SceneOverlaySetting
{
    public string sceneName;

    [Range(0f,1f)]
    public float opacity = 0.5f;
}

public class SceneBackgroundController : MonoBehaviour
{
    public static SceneBackgroundController Instance;

    [Header("UI Background Image")]
    public Image overlay;

    [Header("Transition")]
    public float fadeSpeed = 2f;

    [Header("Scene Settings")]
    public SceneOverlaySetting[] sceneSettings;

    Coroutine fadeRoutine;

    private void Awake()
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

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        UpdateOverlay(
            SceneManager.GetActiveScene().name
        );
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateOverlay(scene.name);
    }

    void UpdateOverlay(string sceneName)
    {
        float targetOpacity = 0f;

        foreach(SceneOverlaySetting setting in sceneSettings)
        {
            if(setting.sceneName == sceneName)
            {
                targetOpacity = setting.opacity;
                break;
            }
        }

        if(fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }

        fadeRoutine =
            StartCoroutine(
                FadeTo(targetOpacity)
            );
    }

    IEnumerator FadeTo(float target)
    {
        float start =
            overlay.color.a;

        float t = 0f;

        while(t < 1f)
        {
            t += Time.deltaTime * fadeSpeed;

            Color c = overlay.color;

            c.a =
                Mathf.Lerp(
                    start,
                    target,
                    t
                );

            overlay.color = c;

            yield return null;
        }

        Color final = overlay.color;
        final.a = target;
        overlay.color = final;
    }
}