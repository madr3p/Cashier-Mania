using UnityEngine;

public class IconMotionAdvanced : MonoBehaviour
{
    [Header("Position Motion")]
    public float moveSpeed = 1f;
    public float verticalAmount = 8f;
    public float horizontalAmount = 3f;

    [Header("Scale Motion (Breathing)")]
    public bool enableScale = true;
    public float scaleSpeed = 1f;
    public float scaleAmount = 0.1f;
    public float baseScale = 1f;

    [Header("Rotation Motion (Optional)")]
    public bool enableRotation = false;
    public float rotationSpeed = 20f;
    public float rotationAmount = 5f;

    private Vector3 startPos;
    private Vector3 startScale;
    private Quaternion startRot;

    void Start()
    {
        startPos = transform.localPosition;
        startScale = transform.localScale;
        startRot = transform.localRotation;
    }

    void Update()
    {
        // POSITION FLOAT
        float y = startPos.y + Mathf.Sin(Time.time * moveSpeed) * verticalAmount;
        float x = startPos.x + Mathf.Cos(Time.time * moveSpeed * 0.5f) * horizontalAmount;

        transform.localPosition = new Vector3(x, y, startPos.z);

        // SCALE BREATHING
        if (enableScale)
        {
            float scaleOffset = Mathf.Sin(Time.time * scaleSpeed) * scaleAmount;
            float finalScale = baseScale + scaleOffset;

            transform.localScale = startScale * finalScale;
        }

        // ROTATION WOBBLE
        if (enableRotation)
        {
            float rotZ = Mathf.Sin(Time.time * rotationSpeed) * rotationAmount;
            transform.localRotation = startRot * Quaternion.Euler(0, 0, rotZ);
        }
    }
}