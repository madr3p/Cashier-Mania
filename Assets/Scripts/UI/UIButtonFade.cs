using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIButtonFadeIn : MonoBehaviour
{
    [Header("Fade Settings")]
    public float delay = 0f;
    public float fadeSpeed = 1f;

    [Range(0f, 1f)]
    public float targetOpacity = 1f;

    public bool playOnStart = true;

    private CanvasGroup canvasGroup;

    void Awake()
    {
        // Add or get CanvasGroup (controls whole UI hierarchy)
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();

        canvasGroup.alpha = 0f;
    }

    void Start()
    {
        if (playOnStart)
        {
            StartFade();
        }
    }

    public void StartFade()
    {
        StopAllCoroutines();
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(delay);

        float t = 0f;
        float startAlpha = canvasGroup.alpha;

        while (t < 1f)
        {
            t += Time.deltaTime * fadeSpeed;

            canvasGroup.alpha =
                Mathf.Lerp(startAlpha, targetOpacity, t);

            yield return null;
        }

        canvasGroup.alpha = targetOpacity;
    }
}