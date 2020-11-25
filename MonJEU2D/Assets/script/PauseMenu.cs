using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsWindowsPause;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.P))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        MovePlayer.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
    MovePlayer.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void Settings()
    {
        settingsWindowsPause.SetActive(true);
    }

    public void Onclose()
    {
        settingsWindowsPause.SetActive(false);
    }

    public void LoadMainMenu()
    {
        
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}