using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossCreep : UnitCard
{
    public override void DestroyThisCard()
    {
        GameMaster.GetInstance().GameGoodEnd();
    }
}
