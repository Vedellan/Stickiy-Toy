using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    GameObject gameOverPanel;
    [SerializeField]
    TextMeshProUGUI scoreText;

    private void Awake()
    {
        gameOverPanel = GameObject.Find("GameOverPanel");
        scoreText = GameObject.Find("Score Text (TMP)").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.onGameStart.AddListener(GameStart_UIManager);
        GameManager.Instance.onGameOver.AddListener(GameOver_UIManager);
    }

    /*private void OnEnable()
    {
        GameManager.instance.onGameStart.AddListener(CloseGameOverUI);
        GameManager.instance.onGameOver.AddListener(OpenGameOverUI);
    }*/

    private void OnDisable()
    {
        GameManager.Instance.onGameStart.RemoveListener(GameStart_UIManager);
        GameManager.Instance.onGameOver.RemoveListener(GameOver_UIManager);
    }

    private void GameStart_UIManager()
    {
        CloseGameOverUI();
    }

    private void GameOver_UIManager()
    {
        ShowScore();
        OpenGameOverUI();
    }

    private void OpenGameOverUI()
    {
        gameOverPanel.SetActive(true);
    }

    private void CloseGameOverUI()
    {
        gameOverPanel.SetActive(false);
    }

    void ShowScore()
    {
        scoreText.text = "You survived " + (int)GameManager.Instance.GameTime + " seconds!";
    }
}
