using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;

    public static GameManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = FindAnyObjectByType<GameManager>();
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
