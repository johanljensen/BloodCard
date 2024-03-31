using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public bool GameOver = false;
    public void GameGoodEnd()
    {
        if(!GameOver)
        {
            GameOver = true;
            SceneManager.LoadScene("GoodEnding");
        }
    }

    public void GameBadEnd()
    {
        Debug.Log("Lost?");
        if (!GameOver)
        {
            Debug.Log("Yes lost");
            GameOver = true;
            SceneManager.LoadScene("BadEnding");
        }
    }

    private GameState currentState;
    public GameState GetGameState() {  return currentState; }
    public void SetGameState(GameState newState) { currentState = newState; }
}
