using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;

    public enum TransitionType
    {
        FadeIn,
        FadeOut,
        Both
    }

    [Header("Fade Settings")]
    public Image fadeImage;

    public float fadeSpeed = 2f;

    public TransitionType transitionType =
        TransitionType.Both;

    private void Awake()
    {
        if(Instance == null)
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

    void OnSceneLoaded(
        Scene scene,
        LoadSceneMode mode
    )
    {
        if(
            transitionType ==
            TransitionType.FadeIn
            ||
            transitionType ==
            TransitionType.Both
        )
        {
            StartCoroutine(
                Fade(
                    1f,
                    0f
                )
            );
        }
    }

    public void ChangeScene(
        string sceneName
    )
    {
        StartCoroutine(
            ChangeRoutine(
                sceneName
            )
        );
    }

    IEnumerator ChangeRoutine(
        string sceneName
    )
    {
        if(
            transitionType ==
            TransitionType.FadeOut
            ||
            transitionType ==
            TransitionType.Both
        )
        {
            yield return StartCoroutine(
                Fade(
                    0f,
                    1f
                )
            );
        }

        SceneManager.LoadScene(
            sceneName
        );
    }

    IEnumerator Fade(
        float start,
        float target
    )
    {
        float t = 0f;

        Color c = fadeImage.color;
        c.a = start;
        fadeImage.color = c;

        while(t < 1)
        {
            t += Time.deltaTime * fadeSpeed;

            c.a =
                Mathf.Lerp(
                    start,
                    target,
                    t
                );

            fadeImage.color = c;

            yield return null;
        }

        c.a = target;
        fadeImage.color = c;
    }
}