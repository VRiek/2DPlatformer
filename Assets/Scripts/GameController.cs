using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int progressAmount;
    public Slider progressSlider;

    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    public GameObject pauseMenu;
    //public TMP_Text playerDiedText;
    //public static event Action OnReset;
    public bool isPaused = false;

    private void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;
        Gem.OnGemCollect += IncreaseProgressAmount;
        PlayerHealth.OnPlayerDied += GameOverScreen;
        gameOverScreen.SetActive(false);
        victoryScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }


    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pauseMenu.SetActive(isPaused);
    }

    void VictoryScreen()
    {
        if (victoryScreen != null)
        {
            victoryScreen.SetActive(true);
        }
        else
        {
            Debug.Log("Victory screen is null");
        }
        Time.timeScale = 0f;
    }
    void GameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
        else
        {
            Debug.Log("Game over screen is null");
        }
        
        Time.timeScale = 0;
    }

    public void ResetGame()
    {
        progressAmount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        progressSlider.value = progressAmount;

        if (progressAmount >= 100)
        {
            VictoryScreen();
            Debug.Log("Level complete!");
        }
    }
}
