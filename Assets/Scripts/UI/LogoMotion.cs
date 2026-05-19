using UnityEngine;

public class LogoFloat : MonoBehaviour
{
    public float speed = 1f;
    public float verticalAmount = 8f;
    public float horizontalAmount = 3f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float y = startPos.y + Mathf.Sin(Time.time * speed) * verticalAmount;
        float x = startPos.x + Mathf.Cos(Time.time * speed * 0.5f) * horizontalAmount;

        transform.localPosition = new Vector3(x, y, startPos.z);
    }
}