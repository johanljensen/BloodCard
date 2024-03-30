using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToPlaySlot : MonoBehaviour
{
    private static ToPlaySlot Instance;

    public static ToPlaySlot GetInstance()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType<ToPlaySlot>();
        }
        return Instance;
    }

    [SerializeField]
    Card cardBeingPlayed;


    public void SetCardToPlay(Card card)
    {
        cardBeingPlayed = card;

        card.transform.parent = transform;
        card.transform.position = transform.position;
        card.transform.localScale = Vector3.one;

        GameBoard.GetInstance().TestPlayableTiles(card);
    }

    public Card PutCardBack(HandSlot handSlot)
    {
        Card cardToReturn = cardBeingPlayed;
        cardBeingPlayed = null;
        return cardToReturn;
    }

    private void OnMouseDown()
    {
        if(cardBeingPlayed != null)
        {
            if(cardBeingPlayed.CanBeInfused())
            {
                cardBeingPlayed.Infuse();
            }
        }
    }
}
