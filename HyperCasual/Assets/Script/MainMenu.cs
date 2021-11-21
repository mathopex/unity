using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject gameManager;
    public GameObject panelSettings;


    public static MainMenu instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'un instance de CurrentSceneManager dans cette scene");
            return;
        }

        instance = this;

 

    }


    public void ButtonStart()
    {
        SceneManager.LoadScene("Level1");
       
    }


    public void ActiverMenuAide()
    {
        gameManager.GetComponent<AideMenu>().enabled = false;

    }

    public void OuvrePanel()
    {
        panelSettings.SetActive(true);
    }

    public void ClosePanel()
    {
        panelSettings.SetActive(false);
    }




}
