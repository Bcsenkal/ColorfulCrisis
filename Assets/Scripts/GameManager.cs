using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameIsActive = false;
    public bool gameIsPaused = false;
    [SerializeField] private GameObject infoScreen;
    [SerializeField] private GameObject sliders;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject winScreen;
    static GameManager instance;
    
    private void Awake() 
    {
        Time.timeScale = 0;
    }

    private void Update() 
    {
        GameStateChange();
        SetTimeScale();
    }

    public void StartGame()
    {
        gameIsActive = true;
        infoScreen.SetActive(false);
        sliders.SetActive(true);
    }
    
    public void GameStateChange()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsActive)
            {
                if(!gameIsPaused)
                {
                    PauseGame();
                }
                else if(gameIsPaused)
                {
                    ResumeGame();
                }
            }
        }
    }

    public void SetTimeScale()
    {
        if(gameIsActive)
        {
            Time.timeScale = gameIsPaused ? 0 : 1;
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        gameIsPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        gameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Win()
    {
        gameIsActive = false;
        winScreen.SetActive(true);
    }
}
