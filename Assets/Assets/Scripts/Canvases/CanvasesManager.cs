using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasesManager : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject FPSCanvas;
    public GameObject GameOverCanvas;
    public TMPro.TextMeshProUGUI GameOverText;

    bool inMenu = false;
    bool inGameOver = false;

    void Awake()
    {
        GameManager.OnGameStateChange += GameManagerOnGameStateChanged;
    }

    void OnDestroy()
    {
        GameManager.OnGameStateChange -= GameManagerOnGameStateChanged;
    }

    void Update()
    {
        if (inMenu)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PlayButtonPressed();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitButtonPressed();
            }
        }
        else if (inGameOver) 
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                RestartGamePressed();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                QuitButtonPressed();
            }
        }
    }

    void GameManagerOnGameStateChanged(BaseGameState state)
    {
        inMenu = state == GameManager.Instance.MainMenuState;
        inGameOver = state == GameManager.Instance.GameOverState;

        MainMenuCanvas.SetActive(state == GameManager.Instance.MainMenuState);
        FPSCanvas.SetActive(state == GameManager.Instance.PlayingState);

        if (state == GameManager.Instance.GameOverState)
        {
            GameOverText.text = GameManager.Instance.gameOverReason;
        }

        GameOverCanvas.SetActive(state == GameManager.Instance.GameOverState);
    }

    // Main Menu
    public void PlayButtonPressed()
    {
        GameManager.Instance.SwitchState(GameManager.Instance.PlayingState);
    }

    public void QuitButtonPressed()
    {
        GameManager.Instance.SwitchState(GameManager.Instance.QuitState);
    }

    // Paused Menu
    public void ContinueButtonPressed()
    {
        GameManager.Instance.SwitchState(GameManager.Instance.PlayingState);
    }

    public void MenuButtonPressed()
    {
        GameManager.Instance.SwitchState(GameManager.Instance.MainMenuState);
    }

    public void RestartGamePressed()
    {
        SceneManager.LoadScene("GameScene");
    }
}

