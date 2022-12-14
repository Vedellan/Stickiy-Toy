using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameManager : Singleton<GameManager>
{
    public UnityEvent onGameStart;
    public UnityEvent onGameOver;

    GameInput gameInput;

    private float gameTime = 0f;
    public float GameTime
    {
        get
        {
            return gameTime;
        }
    }

    private void Awake()
    {
        gameInput = new GameInput();
    }

    private void Start()
    {
        onGameStart.AddListener(GameStart_GameManager);
        onGameOver.AddListener(GameOver_GameManager);

        onGameStart.Invoke();
    }

    private void Update()
    {
        gameTime += Time.deltaTime;
        Debug.Log(gameTime);
    }

    private void OnEnable()
    {
        gameInput.GameActions.Restart.started += RestartGame;
    }

    private void OnDisable()
    {
        gameInput.GameActions.Restart.started -= RestartGame;
    }

    private void GameOver_GameManager()
    {
        Time.timeScale = 0f;
    }

    private void GameStart_GameManager()
    {
        Time.timeScale = 1f;
        gameTime = 0f;
    }

    public void RestartGame(InputAction.CallbackContext ctx)
    {
        onGameStart.Invoke();
    }
}
