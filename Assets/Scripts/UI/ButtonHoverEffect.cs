using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    public float scaleAmount = 1.1f;
    public float moveAmount = 5f;
    public float smoothSpeed = 10f;
    public float clickDelay = 0.15f;

    [Header("Button Type")]
    public bool isSceneButton = false;

    private Vector3 originalScale;
    private Vector3 originalPosition;

    private Vector3 targetScale;
    private Vector3 targetPosition;

    private bool isHovered;

    void Start()
    {
        originalScale = transform.localScale;
        originalPosition = transform.localPosition;

        targetScale = originalScale;
        targetPosition = originalPosition;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            targetScale,
            Time.deltaTime * smoothSpeed
        );

        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            targetPosition,
            Time.deltaTime * smoothSpeed
        );
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;

        if (CursorManager.Instance != null)
            CursorManager.Instance.SetHandPoint();

        targetScale = originalScale * scaleAmount;
        targetPosition = originalPosition + new Vector3(0, moveAmount, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;

        if (CursorManager.Instance != null)
            CursorManager.Instance.SetPointer();

        targetScale = originalScale;
        targetPosition = originalPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (CursorManager.Instance != null)
            CursorManager.Instance.SetHandClosed();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isSceneButton)
        {
            if (CursorManager.Instance != null)
                CursorManager.Instance.SetLoading();
        }
        else
        {
            Invoke(nameof(RestoreCursor), clickDelay);
        }
    }

    void RestoreCursor()
    {
        if (CursorManager.Instance == null)
            return;

        if (isHovered)
            CursorManager.Instance.SetHandPoint();
        else
            CursorManager.Instance.SetPointer();
    }
}