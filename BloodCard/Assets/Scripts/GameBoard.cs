using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    private static GameBoard Instance;

    public static GameBoard GetInstance()
    {
        if(Instance == null)
        {
            Instance = FindObjectOfType<GameBoard>();
        }
        return Instance;
    }

    [SerializeField]
    List<BoardTile> boardTiles;

    private void OnValidate()
    {
        if (boardTiles.Count == 0)
        {
            boardTiles = GetComponentsInChildren<BoardTile>().ToList();
        }
    }

    public void AddClaimToTile(int tileFromX, int tileFromY, int xOffset, int yOffset, bool playerAllegiance)
    {
        int targetX = tileFromX + xOffset;
        int targetY = tileFromY + yOffset;

        foreach(BoardTile tile in boardTiles)
        {
            if(targetX == tile.tileX && targetY == tile.tileY)
            {
                tile.AddClaim(playerAllegiance);
            }
        }
    }

    public void TestPlayableTiles(Card cardBeingPlayed)
    {

    }
}
