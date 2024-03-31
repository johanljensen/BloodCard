using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    GameObject infuseText;

    private void Awake()
    {
        infuseText.gameObject.SetActive(false);
    }

    public void SetCardToPlay(Card card, HandSlot slot)
    {
        if(cardBeingPlayed != null)
        {
            PutCardBack(slot);
        }

        cardBeingPlayed = card;

        card.transform.parent = transform;
        card.transform.position = transform.position;
        card.transform.localScale = Vector3.one;

        if(cardBeingPlayed.CanBeInfused())
        {
            infuseText.SetActive(true);
        }

        GameBoard.GetInstance().TestPlayableTiles(card);
    }

    public Card GetCardBeingPlayed() 
    {
        return cardBeingPlayed; 
    }

    public void PutCardBack(HandSlot handSlot)
    {
        if(cardBeingPlayed== null) { return; }

        cardBeingPlayed.ResetInfuse();
        infuseText.SetActive(false);
        handSlot.AddCardToSlot(cardBeingPlayed);
        cardBeingPlayed = null;
    }

    public void RemoveCard()
    {
        cardBeingPlayed = null;
        infuseText.SetActive(false);
    }

    private void OnMouseDown()
    {
        if(cardBeingPlayed != null)
        {
            if(cardBeingPlayed.CanBeInfused())
            {
                cardBeingPlayed.Infuse();

                if(!cardBeingPlayed.CanBeInfused())
                {
                    infuseText.SetActive(false);
                }
            }
        }
    }
}
