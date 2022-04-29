using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameStates
    {
        IsGameLoaded,
        IsGamePlaying,
        IsLevelPass
    }

    public GameStates GameState;


    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        GameState = GameStates.IsGameLoaded;
    }


    public void RestartGame()
    {
        GameState = GameStates.IsGameLoaded;

        LevelManager.Instance.GenerateLevel();

        CanvasManager.Instance.InGamePanel.ActivateTapToStartButton();

        LevelManager.Instance.ResetPickNumber();
        CanvasManager.Instance.InGamePanel.SetPickText();

        StopAllCoroutines();

    }
}
