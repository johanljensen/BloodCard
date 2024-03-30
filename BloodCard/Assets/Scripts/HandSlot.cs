using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private void OnMouseDown()
    {
        if(cardInSlot != null)
        {
            ToPlaySlot.GetInstance().SetCardToPlay(cardInSlot);
        }
        else
        {
            Card returnCard = ToPlaySlot.GetInstance().PutCardBack(this);
            cardInSlot = returnCard;

            cardInSlot.transform.parent = transform;
            cardInSlot.transform.position = transform.position;
            cardInSlot.transform.localScale = Vector3.one;
        }
    }
}
