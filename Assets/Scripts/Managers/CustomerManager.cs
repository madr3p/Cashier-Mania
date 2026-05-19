using UnityEngine;

public class CustomerOrderGenerator : MonoBehaviour
{
    public GameObject[] itemPrefabs;

    public Transform spawnArea;

    public int minItems = 1;
    public int maxItems = 5;

    void Start()
    {
        GenerateOrder();
    }

    public void GenerateOrder()
    {
        int itemCount = Random.Range(minItems, maxItems + 1);

        for(int i = 0; i < itemCount; i++)
        {
            int randomIndex =
                Random.Range(0, itemPrefabs.Length);

            Vector2 randomPos =
                new Vector2(
                    Random.Range(-150,150),
                    Random.Range(-50,50)
                );

            GameObject item =
                Instantiate(
                    itemPrefabs[randomIndex],
                    spawnArea
                );

            item.GetComponent<RectTransform>()
                .anchoredPosition = randomPos;
        }
    }
}