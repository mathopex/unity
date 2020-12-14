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
    public int levelConitnue;
   
     private void Start()
    {
        levelConitnue = PlayerPrefs.GetInt("idCurrentScene");

        //levelConitnue = LevelSelector.instance.levelReach;
        if (levelConitnue < 1)
        {
            continueGame.interactable = false;
        }
        else if(levelConitnue >= 1)
        {
            continueGame.interactable = true;
        }

       
       
    }
    public void NewGame()
    {

        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }

    public void ContinueGame()
    {
    
            SceneManager.LoadScene(levelConitnue); 
        
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
