using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    GameObject gameOverPanel;

    private void Awake()
    {
        gameOverPanel = GameObject.Find("GameOverPanel");
    }

    private void Start()
    {
        GameManager.Instance.onGameStart.AddListener(CloseGameOverUI);
        GameManager.Instance.onGameOver.AddListener(OpenGameOverUI);
    }

    /*private void OnEnable()
    {
        GameManager.instance.onGameStart.AddListener(CloseGameOverUI);
        GameManager.instance.onGameOver.AddListener(OpenGameOverUI);
    }*/

    private void OnDisable()
    {
        GameManager.Instance.onGameStart.RemoveListener(CloseGameOverUI);
        GameManager.Instance.onGameOver.RemoveListener(OpenGameOverUI);
    }

    void OpenGameOverUI()
    {
        gameOverPanel.SetActive(true);
    }

    void CloseGameOverUI()
    {
        gameOverPanel.SetActive(false);
    }
}
