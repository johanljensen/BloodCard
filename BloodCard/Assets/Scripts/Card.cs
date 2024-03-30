using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    Sprite cardImage;

    [TextArea]
    [SerializeField]
    string cardText;

    [SerializeField]
    int claimCost;

    [Space(10)]
    [Header("Infusion")]
    [SerializeField]
    bool infusionCard;

    [SerializeField]
    int infusionMax;

    [SerializeField]
    int infusedAmount;

    public bool CanBeInfused()
    {
        return infusionCard && infusedAmount < infusionMax;
    }
    public void Infuse()
    {
        infusedAmount++;
    }

    private void Awake()
    {
        if(cardImage == null)
        {
            cardImage = GetComponentInChildren<SpriteRenderer>().sprite;
        }
    }

    public Sprite GetCardImage()
    { return cardImage; }

    public string GetCardText()
    { return cardText; }
}
