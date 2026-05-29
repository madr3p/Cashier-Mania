using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    [Header("Difficulty")]
    public int lives = 3;

    public int minItems = 3;
    public int maxItems = 6;

    public float customerTime = 45f;

    public int totalCustomers = 10;

    [Header("Customer")]
    public Sprite[] customerSprites;
    public Image customerImage;

    [Header("Items")]
    public GameObject[] itemPrefabs;
    public Transform spawnArea;

    [Header("Monitor UI")]
    public TMP_Text itemNameText;
    public TMP_Text itemPriceText;
    public TMP_Text totalText;
    public TMP_Text customerMoneyText;
    public TMP_Text balanceNeededText;
    public TMP_Text balanceGivingText;

    [Header("Game UI")]
    public TMP_Text timerText;
    public TMP_Text livesText;
    public TMP_Text customersLeftText;
    public TMP_Text feedbackText;

    private List<GameObject> currentItems =
        new List<GameObject>();

    private float totalAmount;
    private float customerMoney;
    private float balanceNeeded;
    private float playerBalance;

    private int scannedItems;
    private int customersLeft;

    private Coroutine timerRoutine;

    private bool gameEnded;

    void Start()
    {
        customersLeft = totalCustomers;

        UpdateUI();

        SpawnCustomer();
    }

    //--------------------------------
    // CUSTOMER
    //--------------------------------

    void SpawnCustomer()
    {
        if(gameEnded)
            return;

        if(customersLeft <= 0)
        {
            WinGame();
            return;
        }

        SoundManager.Instance.PlayNextCustomer();

        ClearItems();

        totalAmount = 0;
        customerMoney = 0;
        balanceNeeded = 0;
        playerBalance = 0;
        scannedItems = 0;

        itemNameText.text = "-";
        itemPriceText.text = "RM0.00";

        totalText.text =
            "Total: RM0.00";

        customerMoneyText.text =
            "Customer Pays: ???";

        balanceNeededText.text =
            "Balance: RM0.00";

        balanceGivingText.text =
            "Balance Giving: RM0.00";

        feedbackText.text = "";

        customerImage.sprite =
            customerSprites[
                Random.Range(
                    0,
                    customerSprites.Length
                )
            ];

        GenerateItems();

        if(timerRoutine != null)
        {
            StopCoroutine(
                timerRoutine
            );
        }

        timerRoutine =
            StartCoroutine(
                CustomerTimer()
            );
    }

    IEnumerator CustomerTimer()
    {
        float timeLeft =
            customerTime;

        while(
            timeLeft > 0 &&
            !gameEnded
        )
        {
            timerText.text =
                "Time: " +
                Mathf.Ceil(
                    timeLeft
                );

            timeLeft -=
                Time.deltaTime;

            yield return null;
        }

        if(gameEnded)
            yield break;

        feedbackText.text =
            "Customer Left";

        LoseLife();

        customersLeft--;

        UpdateUI();

        yield return new WaitForSeconds(
            1f
        );

        SpawnCustomer();
    }

    //--------------------------------
    // ITEMS
    //--------------------------------

    void GenerateItems()
    {
        int count =
            Random.Range(
                minItems,
                maxItems + 1
            );

        for(
            int i=0;
            i<count;
            i++
        )
        {
            int randomItem =
                Random.Range(
                    0,
                    itemPrefabs.Length
                );

            GameObject item =
                Instantiate(
                    itemPrefabs[randomItem],
                    spawnArea
                );

            item.GetComponent
            <RectTransform>()
            .anchoredPosition =
            new Vector2(
                Random.Range(
                    -150,
                    150
                ),
                Random.Range(
                    -50,
                    50
                )
            );

            currentItems.Add(
                item
            );
        }
    }

    public void ScanItem(
        ItemData item
    )
    {
        if(gameEnded)
            return;

        itemNameText.text =
            item.itemName;

        itemPriceText.text =
            "RM " +
            item.itemPrice
            .ToString("F2");

        totalAmount +=
            item.itemPrice;

        totalText.text =
            "Total: RM " +
            totalAmount
            .ToString("F2");

        scannedItems++;

        SoundManager.Instance.PlayScan();
        Debug.Log("SCAN SOUND PLAYED");

        Destroy(
            item.gameObject
        );

        if(
            scannedItems
            >= currentItems.Count
        )
        {
            GenerateCustomerPayment();
        }
    }

    //--------------------------------
    // PAYMENT
    //--------------------------------

    void GenerateCustomerPayment()
    {
        float multiplier =
            Random.Range(
                1.3f,
                3f
            );

        customerMoney =
            Mathf.Ceil(
                totalAmount
                *
                multiplier
                *
                10
            ) / 10f;

        customerMoneyText.text =
            "Customer Pays: RM" +
            customerMoney
            .ToString("F2");

        balanceNeeded =
            customerMoney
            -
            totalAmount;

        balanceNeededText.text =
            "Balance: RM " +
            balanceNeeded
            .ToString("F2");
    }

    public void AddMoney(
        float amount
    )
    {
        if(gameEnded)
            return;

        playerBalance +=
            amount;

        UpdateBalanceUI();
    }

    public void RemoveMoney(
        float amount
    )
    {
        if(gameEnded)
            return;

        playerBalance -=
            amount;

        if(
            playerBalance < 0
        )
        {
            playerBalance = 0;
        }

        UpdateBalanceUI();
    }

    void UpdateBalanceUI()
    {
        balanceGivingText.text =
            "Balance Giving: RM" +
            playerBalance
            .ToString("F2");
    }

    //--------------------------------
    // VALIDATION
    //--------------------------------

    public void ValidateTransaction()
{
    if(gameEnded)
        return;

    // Player gave nothing
    if(playerBalance <= 0f)
    {
        feedbackText.text =
            "No Balance Given";

        LoseLife();

        customersLeft--;

        UpdateUI();

        StopCoroutine(
            timerRoutine
        );

        StartCoroutine(
            NextCustomer()
        );

        return;
    }

    // Correct balance
    if(
        Mathf.Abs(
            playerBalance
            -
            balanceNeeded
        ) < 0.01f
    )
    {
        feedbackText.text =
            "Correct";

        customersLeft--;
    }
    else
    {
        feedbackText.text =
            "Wrong!";

        LoseLife();

        customersLeft--;
    }

    UpdateUI();

    if(timerRoutine != null)
    {
        StopCoroutine(
            timerRoutine
        );
    }

    StartCoroutine(
        NextCustomer()
    );
}

    IEnumerator NextCustomer()
    {
        yield return new WaitForSeconds(
            1f
        );

        SpawnCustomer();
    }

    //--------------------------------
    // GAME
    //--------------------------------

    void LoseLife()
    {
        lives--;

        livesText.text =
            "Lives: " +
            lives;

        if(
            lives <= 0
        )
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameEnded = true;

        SoundManager.Instance.PlayLevelLose();
        
        StopAllCoroutines();

        feedbackText.text =
            "GAME OVER";

        StartCoroutine(
            ReturnToMenu()
        );
    }

    void WinGame()
    {
        gameEnded = true;

        SoundManager.Instance.PlayLevelComplete();

        StopAllCoroutines();

        feedbackText.text =
            "YOU WIN";

        StartCoroutine(
            ReturnToMenu()
        );
    }

    IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(
            2f
        );

        SceneManager.LoadScene(
            "LevelSelection"
        );
    }

    //--------------------------------
    // UI
    //--------------------------------

    void UpdateUI()
    {
        livesText.text =
            "Lives: " +
            lives;

        customersLeftText.text =
            "Customers Left: " +
            customersLeft;
    }

    void ClearItems()
    {
        foreach(
            GameObject item
            in currentItems
        )
        {
            if(item!=null)
            {
                Destroy(item);
            }
        }

        currentItems.Clear();
    }
}