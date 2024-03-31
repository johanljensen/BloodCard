using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer cardImage;

    [TextArea]
    [SerializeField]
    string cardText;

    [SerializeField]
    protected int claimCost;

    [Space(10)]
    [Header("Infusion")]
    [SerializeField]
    bool infusionCard;

    [SerializeField]
    protected int infusionMax;

    [SerializeField]
    protected int infusedAmount;

    [SerializeField]
    GameObject infuseImage;

    public bool CanBeInfused()
    {
        return infusionCard && infusedAmount < infusionMax;
    }
    public void Infuse()
    {
        infusedAmount++;
        ShowInfused(true);
    }

    public void ResetInfuse()
    {
        infusedAmount = 0;
        ShowInfused(false);
    }

    public void ShowInfused(bool show)
    {
        infuseImage.SetActive(show);
    }

    private void Awake()
    {
        infuseImage.SetActive(false);
    }

    public Sprite GetCardImage()
    { return cardImage.sprite; }

    public string GetCardText()
    { return cardText; }

    public virtual bool CanPlayOnTile(BoardTile tile, UnitCard tileUnit)
    {
        return tile.GetClaim(true) >= claimCost;
    }

    public virtual void DestroyThisCard()
    {
        Destroy(gameObject);
    }
}
