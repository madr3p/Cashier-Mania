using UnityEngine;
using UnityEngine.EventSystems;

public class MoneyButton :
MonoBehaviour,
IPointerClickHandler
{
    public GameplayManager manager;

    public float amount;

    public void OnPointerClick(
        PointerEventData eventData
    )
    {
        if(
            eventData.button ==
            PointerEventData
            .InputButton.Left
        )
        {
            manager.AddMoney(
                amount
            );
        }

        if(
            eventData.button ==
            PointerEventData
            .InputButton.Right
        )
        {
            manager.RemoveMoney(
                amount
            );
        }
    }
}