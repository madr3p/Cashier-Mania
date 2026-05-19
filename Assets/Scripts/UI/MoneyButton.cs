using UnityEngine;

public class MoneyButton : MonoBehaviour
{
    public GameplayManager manager;

    public float amount;

    public void GiveMoney()
    {
        manager.GiveMoney(amount);
    }
}