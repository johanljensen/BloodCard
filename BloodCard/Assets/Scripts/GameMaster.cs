using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster Instance;

    public static GameMaster GetInstance()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType<GameMaster>();
        }
        return Instance;
    }

    public enum GameState
    {
        None,
        PlayerChoosing,
        HoldingCard,
        OppenentPlaying
    }

    private GameState currentState;
    public GameState GetGameState() {  return currentState; }
    public void SetGameState(GameState newState) { currentState = newState; }
}
