using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelector : MonoBehaviour
{
    public GameObject settingsWindows;
    public void LoadLevelPassed(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Settings()
    {
        settingsWindows.SetActive(true);
    }

    public void Onclose()
    {
        settingsWindows.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
