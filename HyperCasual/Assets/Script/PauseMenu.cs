using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;


    // Update is called once per frame
    void Update()
    {
        OpenPause();
    }


    private void OpenPause()
    {
        //si il est deja actif on le desactive
        if (pauseMenu.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }

        }
        else
        {
            //si il est pas actif on l'active s
            if (Input.GetKeyDown(KeyCode.P))
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }

        }
    }

    public void Retour()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }


    public void Option()
    {
        //appelle fonction option

    }

    public void RetourLvlSelector()
    {
        SceneManager.LoadScene(1);
    }

}
