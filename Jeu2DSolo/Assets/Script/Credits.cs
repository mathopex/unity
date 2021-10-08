using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }
}
