﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menuAide;
    public GameObject boutonClose;
    
    public void ButtonStart()
    {
        SceneManager.LoadScene("Level1");
    }


 

}
