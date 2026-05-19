using UnityEngine;

public class Scanner : MonoBehaviour
{
    public GameplayManager manager;

    RectTransform scannerRect;

    void Start()
    {
        scannerRect = GetComponent<RectTransform>();
    }

    void Update()
    {
        UIGrabbable[] items =
            Object.FindObjectsByType<UIGrabbable>(
                FindObjectsSortMode.None
            );

        foreach (UIGrabbable item in items)
        {
            RectTransform itemRect =
                item.GetComponent<RectTransform>();

            bool inside =
                RectTransformUtility.RectangleContainsScreenPoint(
                    scannerRect,
                    itemRect.position
                );

            if (inside)
            {
                ItemData data =
                    item.GetComponent<ItemData>();

                if (data != null)
                {
                    manager.ScanItem(data);
                }
            }
        }
    }
}