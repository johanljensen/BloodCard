using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCard : Card
{
    protected int tileX;
    protected int tileY;

    bool isplayerFriendly;

    [SerializeField]
    bool hasAbility;


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
        transform.position = tileTransform.position + new Vector3(0, .1f, 0);
        transform.rotation = tileTransform.rotation;
        transform.Rotate(90, 0, 0);
        transform.localScale = new Vector3(4, 4, 1);

        tileX = x;
        tileY = y;

        ClaimTiles();
        PlayEffect();
    }

    public void ClaimTiles()
    {
        foreach (var claimTile in claimTiles)
        {
            GameBoard.GetInstance().AddClaimToTile(tileX, tileY, claimTile.xOffset, claimTile.yOffset, true);
        }
    }

    public virtual void PlayEffect() { } //To be overwritten by units that have effects

    public override bool CanPlayOnTile(BoardTile tile, UnitCard tileUnit)
    {
        if (tile.GetClaim(true) >= claimCost && tileUnit == null)
        {
            return true;
        }
        return false;
    }
}
