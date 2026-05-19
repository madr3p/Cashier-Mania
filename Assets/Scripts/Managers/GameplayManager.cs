using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayManager : MonoBehaviour
{
    [Header("Customer")]
    public float customerSpawnInterval = 5f;
    public float customerWaitingTime = 30f;

    [Header("Items")]
    public GameObject[] itemPrefabs;
    public Transform spawnArea;

    public int minItems = 1;
    public int maxItems = 5;

    [Header("Display")]
    public TMP_Text itemNameText;
    public TMP_Text itemPriceText;
    public TMP_Text totalText;
    public TMP_Text customerMoneyText;
    public TMP_Text balanceNeededText;
    public TMP_Text balanceGivingText;

    [Header("Money")]
    public float[] moneyValues =
    {
        100f,
        50f,
        20f,
        10f,
        5f,
        1f,
        0.50f,
        0.20f,
        0.10f
    };

    private List<GameObject> currentItems =
        new List<GameObject>();

    private float totalAmount;
    private float customerMoney;
    private float balanceNeeded;

    private float playerGivenBalance;

    private int scannedItems;

    void Start()
    {
        StartCoroutine(CustomerLoop());

        balanceGivingText.text =
            "Balance Giving: RM0.00";
    }

    IEnumerator CustomerLoop()
    {
        while(true)
        {
            yield return new WaitForSeconds(
                customerSpawnInterval
            );

            SpawnCustomer();
        }
    }

    void SpawnCustomer()
    {
        ClearItems();

        totalAmount = 0;
        scannedItems = 0;
        playerGivenBalance = 0;

        GenerateItems();

        customerMoney =
            moneyValues[
                Random.Range(
                    0,
                    moneyValues.Length
                )
            ];

        customerMoneyText.text =
            "Customer Pays: RM" +
            customerMoney.ToString("F2");

        totalText.text =
            "Total: RM0.00";

        balanceNeededText.text =
            "Balance: RM0.00";

        balanceGivingText.text =
            "Balance Giving: RM0.00";

        StartCoroutine(
            CustomerWait()
        );
    }

    IEnumerator CustomerWait()
    {
        yield return new WaitForSeconds(
            customerWaitingTime
        );

        Debug.Log("Customer Left");

        SpawnCustomer();
    }

    void GenerateItems()
    {
        int count =
            Random.Range(
                minItems,
                maxItems + 1
            );

        for(int i=0;i<count;i++)
        {
            int randomItem =
                Random.Range(
                    0,
                    itemPrefabs.Length
                );

            Vector2 randomPos =
                new Vector2(
                    Random.Range(-150,150),
                    Random.Range(-50,50)
                );

            GameObject item =
                Instantiate(
                    itemPrefabs[randomItem],
                    spawnArea
                );

            item.GetComponent<RectTransform>()
            .anchoredPosition =
            randomPos;

            currentItems.Add(item);
        }
    }

    public void ScanItem(ItemData item)
    {
        itemNameText.text =
            item.itemName;

        itemPriceText.text =
            "RM " +
            item.itemPrice.ToString("F2");

        totalAmount +=
            item.itemPrice;

        totalText.text =
            "Total: RM " +
            totalAmount.ToString("F2");

        scannedItems++;

        Destroy(item.gameObject);

        if(scannedItems >= currentItems.Count)
        {
            CalculateBalance();
        }
    }

    void CalculateBalance()
    {
        balanceNeeded =
            customerMoney
            -
            totalAmount;

        balanceNeededText.text =
            "Balance: RM " +
            balanceNeeded.ToString("F2");
    }

    public void GiveMoney(float amount)
    {
        playerGivenBalance += amount;

        balanceGivingText.text =
            "Balance Giving: RM" +
            playerGivenBalance.ToString("F2");

        ValidateBalance();
    }

    public void ValidateBalance()
    {
        if(
            Mathf.Abs(
                playerGivenBalance
                -
                balanceNeeded
            ) < 0.01f
        )
        {
            Debug.Log(
                "Correct Balance"
            );
        }
    }

    void ClearItems()
    {
        foreach(GameObject item in currentItems)
        {
            if(item!=null)
            {
                Destroy(item);
            }
        }

        currentItems.Clear();
    }
}