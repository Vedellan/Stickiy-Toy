using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public UnityEvent onGameStart;
    public UnityEvent onGameOver;

    GameInput gameInput;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        gameInput = new GameInput();
    }

    private void Start()
    {
        onGameOver.AddListener(GameOver);
        onGameStart.AddListener(StartGame);

        onGameStart.Invoke();
    }

    private void OnEnable()
    {
        gameInput.GameActions.Restart.started += RestartGame;
    }

    private void OnDisable()
    {
        gameInput.GameActions.Restart.started -= RestartGame;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
    }

    public void RestartGame(InputAction.CallbackContext ctx)
    {
        onGameStart.Invoke();
    }
}
