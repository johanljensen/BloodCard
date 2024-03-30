using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    int tileX;
    int tileY;

    bool isplayerFriendly;

    [SerializeField]
    bool hasAbility;

    [SerializeField]
    int claimCost;

    [SerializeField]
    int unitPower;

    [Serializable]
    class TileOffset
    {
        public int xOffset;
        public int yOffset;
    }

    [SerializeField]
    List<TileOffset> claimTiles;

    [SerializeField]
    List<TileOffset> effectTiles;


    public void PlayToTile(Transform tileTransform, int x, int y)
    {
        transform.parent = tileTransform;
        transform.position = tileTransform.position;
        transform.rotation = tileTransform.rotation;        

        tileX= x;
        tileY= y;

        ClaimTiles();
        PlayEffect();
    }

    public void ClaimTiles()
    {
        foreach(var claimTile in claimTiles)
        {
            GameBoard.GetInstance().AddClaimToTile(tileX, tileY, claimTile.xOffset, claimTile.yOffset, isplayerFriendly);
        }
    }

    public virtual void PlayEffect() {} //To be overwritten by units that have effects
}
