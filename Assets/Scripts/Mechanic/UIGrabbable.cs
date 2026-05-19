using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UIGrabbable : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IPointerUpHandler
{
    public float gravity = 500f;
    public float floorY = -250f;

    private RectTransform rect;
    private bool isDragging;

    private float velocityY;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (isDragging)
        {
            rect.position = Mouse.current.position.ReadValue();
        }
        else
        {
            velocityY -= gravity * Time.deltaTime;

            rect.anchoredPosition +=
                new Vector2(0, velocityY * Time.deltaTime);

            if(rect.anchoredPosition.y <= floorY)
            {
                Vector2 pos = rect.anchoredPosition;

                pos.y = floorY;

                rect.anchoredPosition = pos;

                velocityY = 0;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        CursorManager.Instance.SetHandOpen();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isDragging)
            CursorManager.Instance.SetPointer();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        velocityY = 0;

        CursorManager.Instance.SetHandClosed();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;

        CursorManager.Instance.SetHandOpen();
    }
}