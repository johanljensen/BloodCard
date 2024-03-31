using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardTile : MonoBehaviour
{
    public int tileX;
    public int tileY;

    [SerializeField]
    int playerClaim;

    [SerializeField]
    int opponentClaim;

    [SerializeField]
    UnitCard myUnit;

    static int unitsPlayed = 0;

    private void Awake()
    {
        unitsPlayed = 0;
    }

    private void OnValidate()
    {
        bool yFirst = false;
        foreach(char character in transform.name)
        {
            if (char.IsNumber(character))
            {
                if(!yFirst)
                {
                    tileY = (int)char.GetNumericValue(character);
                    yFirst = true;
                }
                else
                {
                    tileX = (int)char.GetNumericValue(character);
                }
            }
        }

        UpdateClaimColor();
    }

    public void AddClaim(bool playerAllegiance)
    {
        if(playerAllegiance)
        {
            playerClaim++;
        }
        else
        {
            opponentClaim++;
        }

        UpdateClaimColor();
    }

    public int GetClaim(bool playerAllegiance)
    {
        if(playerAllegiance)
        {
            return playerClaim;
        }
        else
        {
            return opponentClaim;
        }
    }

    public void DestroyUnit()
    {
        myUnit.DestroyThisCard();
    }

    public void UpdateClaimColor()
    {
        SpriteRenderer myTileSprite = GetComponentInChildren<SpriteRenderer>();

        if (playerClaim == 1)
        {
            myTileSprite.color = Color.yellow; //new Color(0, .3f, 0);
        }
        else if (playerClaim == 2)
        {
            myTileSprite.color = Color.cyan; //new Color(0, .6f, 0);
        }
        else if(playerClaim == 3)
        {
            myTileSprite.color = Color.blue; //new Color(0, 1f, 0);
        }
    }

    private void OnMouseEnter()
    {
        if (myUnit != null)
        {
            CardPreview.GetInstance().SetCardPreview(myUnit);
        }
    }

    private void OnMouseExit()
    {
        CardPreview.GetInstance().ClearPreview();
    }

    private void OnMouseDown()
    {
        Debug.Log("Click tile to play card");
        Card tryPlayCard = ToPlaySlot.GetInstance().GetCardBeingPlayed();

        if (tryPlayCard != null)
        {
            Debug.Log("Found card being played");
            if (tryPlayCard.CanPlayOnTile(this, myUnit))
            {
                Debug.Log("Can be played to tile");
                ToPlaySlot.GetInstance().RemoveCard();
                PlayCardToTile(tryPlayCard);

                unitsPlayed++;
            }
        }

        if(unitsPlayed == 5)
        {
            GameMaster.GetInstance().GameBadEnd();
        }
    }

    private void PlayCardToTile(Card cardToPlay)
    {
        if (cardToPlay.GetType().IsSubclassOf(typeof(UnitCard)))
        {
            PlayUnitToTile((UnitCard)cardToPlay);
            
        }
        else if (cardToPlay.GetType().IsSubclassOf(typeof(SpellCard)))
        {
            PlaySpellToTile((SpellCard)cardToPlay);
        }
    }

    private void PlayUnitToTile(UnitCard unitCard)
    {
        unitCard.PlayToTile(transform, tileX, tileY);
    }

    private void PlaySpellToTile(SpellCard spellCard)
    {

    }
}
