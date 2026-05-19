using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeIn : MonoBehaviour
{
    [Header("Fade Settings")]
    public float delay = 0f;

    public float fadeSpeed = 1f;

    [Range(0f,1f)]
    public float targetOpacity = 1f;

    public bool playOnStart = true;

    private Image imageUI;

    void Awake()
    {
        imageUI = GetComponent<Image>();

        Color c = imageUI.color;
        c.a = 0f;
        imageUI.color = c;
    }

    void Start()
    {
        if(playOnStart)
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

        float startAlpha =
            imageUI.color.a;

        float t = 0f;

        while(t < 1f)
        {
            t += Time.deltaTime * fadeSpeed;

            Color c = imageUI.color;

            c.a =
                Mathf.Lerp(
                    startAlpha,
                    targetOpacity,
                    t
                );

            imageUI.color = c;

            yield return null;
        }

        Color final = imageUI.color;
        final.a = targetOpacity;
        imageUI.color = final;
    }
}