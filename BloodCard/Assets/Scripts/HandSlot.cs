using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSlot : MonoBehaviour
{
    [SerializeField]
    Card cardInSlot;

    private void Start()
    {
        Card childCard = GetComponentInChildren<Card>();
        if(childCard != null)
        {
            cardInSlot = childCard;
        }
    }

    public void AddCardToSlot(Card card)
    {
        cardInSlot = card;
    }

    public void RemoveCardFromSlot()
    {
        cardInSlot = null;
    }

    private void OnMouseEnter()
    {
        CardPreview.GetInstance().SetCardPreview(cardInSlot);
    }

    private void OnMouseExit()
    {
        CardPreview.GetInstance().ClearPreview();
    }
}
