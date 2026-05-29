using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIGrabbable : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    [Header("Physics")]
    public float gravity = 500f;

    [Header("Counter Settings")]
    public string counterObjectName = "Counter";

    public float surfaceOffset = 5f;

    private RectTransform rect;
    private RectTransform counterRect;

    private bool isDragging;

    private float velocityY;
    private float floorY;

    void Start()
    {
        rect =
            GetComponent<RectTransform>();

        GameObject counter =
            GameObject.Find(
                counterObjectName
            );

        if(counter != null)
        {
            counterRect =
                counter.GetComponent
                <RectTransform>();

            CalculateFloor();
        }
        else
        {
            Debug.LogWarning(
                "Counter object not found: "
                + counterObjectName
            );
        }
    }

    void Update()
    {
        if(counterRect != null)
        {
            CalculateFloor();
        }

        if(isDragging)
        {
            rect.position =
                Mouse.current.position
                .ReadValue();
        }
        else
        {
            velocityY -=
                gravity *
                Time.deltaTime;

            rect.anchoredPosition +=
                Vector2.up *
                velocityY *
                Time.deltaTime;

            if(
                rect.anchoredPosition.y
                <= floorY
            )
            {
                Vector2 pos =
                    rect.anchoredPosition;

                pos.y =
                    floorY;

                rect.anchoredPosition =
                    pos;

                velocityY = 0;
            }
        }
    }

    void CalculateFloor()
    {
        float counterTop =
            counterRect.anchoredPosition.y
            +
            (
                counterRect.rect.height
                / 2f
            );

        float itemHalfHeight =
            rect.rect.height
            / 2f;

        floorY =
            counterTop
            +
            itemHalfHeight
            +
            surfaceOffset;
    }

    public void OnPointerEnter(
        PointerEventData eventData
    )
    {
        if(
            CursorManager.Instance
            != null
        )
        {
            CursorManager.Instance
                .SetHandOpen();
        }
    }

    public void OnPointerExit(
        PointerEventData eventData
    )
    {
        if(
            !isDragging
            &&
            CursorManager.Instance
            != null
        )
        {
            CursorManager.Instance
                .SetPointer();
        }
    }

    public void OnPointerDown(
        PointerEventData eventData
    )
    {
        isDragging = true;

        velocityY = 0;

        if(
            CursorManager.Instance
            != null
        )
        {
            CursorManager.Instance
                .SetHandClosed();
        }
    }

    public void OnPointerUp(
        PointerEventData eventData
    )
    {
        isDragging = false;

        if(
            CursorManager.Instance
            != null
        )
        {
            CursorManager.Instance
                .SetHandOpen();
        }
    }
}