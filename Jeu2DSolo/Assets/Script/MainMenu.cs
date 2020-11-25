using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsWindows;
    public Button continueGame;

    public string levelToLoad;
    private int teste;
   
     private void Start()
    {
        teste = PlayerPrefs.GetInt("levelBuild");
        
        if (teste == 0)
        {
            continueGame.interactable = false;
        }
        else
        {
            continueGame.interactable = true;
        }
    }
    public void NewGame()
    {
        SceneManager.LoadScene(3);
    }

    public void ContinueGame()
    {
    
            SceneManager.LoadScene(teste); 
        
    }

    public void SelectLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    public void Settings()
    {
        settingsWindows.SetActive(true);
    }

    public void LoadSceneCredit()
    {
        SceneManager.LoadScene("Credits");
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
