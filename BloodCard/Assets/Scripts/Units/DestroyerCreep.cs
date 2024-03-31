using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerCreep : UnitCard
{
    public override void PlayEffect()
    {
        if (infusedAmount == infusionMax)
        {
            GameBoard.GetInstance().DestroyUnitAtTile(tileX, tileY, 0, 1);
        }
    }
}
