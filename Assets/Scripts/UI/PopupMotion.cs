using System.Collections;
using UnityEngine;

public class UIPopUp : MonoBehaviour
{
    [Header("Animation")]
    public float delay = 0f;
    public float duration = 0.4f;

    [Range(1f, 2f)]
    public float popScale = 1.2f;

    public bool playOnStart = true;

    private Vector3 targetScale;
    private Coroutine anim;

    void Awake()
    {
        // Store REAL intended scale (set in inspector)
        targetScale = transform.localScale;

        // Start hidden
        transform.localScale = Vector3.zero;
    }

    void Start()
    {
        if (playOnStart)
            Play();
    }

    public void Play()
    {
        if (anim != null)
            StopCoroutine(anim);

        anim = StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        yield return new WaitForSeconds(delay);

        Vector3 overshoot = targetScale * popScale;

        float t = 0f;

        // pop in
        while (t < 1f)
        {
            t += Time.deltaTime / (duration * 0.7f);

            transform.localScale =
                Vector3.Lerp(Vector3.zero, overshoot, t);

            yield return null;
        }

        t = 0f;

        // settle
        while (t < 1f)
        {
            t += Time.deltaTime / (duration * 0.3f);

            transform.localScale =
                Vector3.Lerp(overshoot, targetScale, t);

            yield return null;
        }

        transform.localScale = targetScale;
        anim = null;
    }
}