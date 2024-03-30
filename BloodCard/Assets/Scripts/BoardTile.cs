using System.Collections;
using System.Collections.Generic;
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
    Unit myUnit;


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
}
