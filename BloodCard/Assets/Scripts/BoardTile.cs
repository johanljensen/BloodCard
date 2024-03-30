using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    private void OnValidate()
    {
        bool xFirst = false;
        foreach(char character in transform.name)
        {
            if (char.IsNumber(character))
            {
                if(!xFirst)
                {
                    tileX = (int)char.GetNumericValue(character);
                    xFirst = true;
                }
                else
                {
                    tileY = (int)char.GetNumericValue(character);
                }
            }
        }
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
    }

    private void OnMouseEnter()
    {
        CardPreview.GetInstance().SetCardPreview(myUnit);
    }

    private void OnMouseExit()
    {
        CardPreview.GetInstance().ClearPreview();
    }
}
