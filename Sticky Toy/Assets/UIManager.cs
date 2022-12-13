using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject gameOverPanel;

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

        gameOverPanel = GameObject.Find("GameOverPanel");
    }

    private void Start()
    {
        GameManager.instance.onGameStart.AddListener(CloseGameOverUI);
        GameManager.instance.onGameOver.AddListener(OpenGameOverUI);
    }

    /*private void OnEnable()
    {
        GameManager.instance.onGameStart.AddListener(CloseGameOverUI);
        GameManager.instance.onGameOver.AddListener(OpenGameOverUI);
    }*/

    private void OnDisable()
    {
        GameManager.instance.onGameStart.RemoveListener(CloseGameOverUI);
        GameManager.instance.onGameOver.RemoveListener(OpenGameOverUI);
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
