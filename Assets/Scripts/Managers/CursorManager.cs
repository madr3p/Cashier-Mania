using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance;

    [Header("Cursor Textures")]
    public Texture2D pointerCursor;
    public Texture2D handPointCursor;
    public Texture2D handOpenCursor;
    public Texture2D handClosedCursor;
    public Texture2D loadingCursor;

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
        }

        SetPointer();
    }

    public void SetPointer()
    {
        Cursor.SetCursor(
            pointerCursor,
            Vector2.zero,
            CursorMode.Auto
        );
    }

    public void SetHandPoint()
    {
        Cursor.SetCursor(
            handPointCursor,
            Vector2.zero,
            CursorMode.Auto
        );
    }

    public void SetHandOpen()
    {
        Cursor.SetCursor(
            handOpenCursor,
            Vector2.zero,
            CursorMode.Auto
        );
    }

    public void SetHandClosed()
    {
        Cursor.SetCursor(
            handClosedCursor,
            Vector2.zero,
            CursorMode.Auto
        );
    }

    public void SetLoading()
    {
        Cursor.SetCursor(
            loadingCursor,
            Vector2.zero,
            CursorMode.Auto
        );
    }
}