using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager Instance;

    public static PlayerManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType<PlayerManager>();
        }
        return Instance;
    }

    Card grabbedCard;

    public Card GetGrabbedCard()
    {
        return grabbedCard;
    }

    public void GrabCard(Card clickedCard)
    {
        grabbedCard = clickedCard;

    }

    public void ReleaseCard()
    {
        grabbedCard = null;
    }

}
