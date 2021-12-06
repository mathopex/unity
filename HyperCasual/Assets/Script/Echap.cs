using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echap : MonoBehaviour
{

    public GameObject popUp;
    void Update()
    {
        if (popUp.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                popUp.SetActive(false);
            }

        }
        else
        {
            //si il est pas actif on l'active 
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                popUp.SetActive(true);
            }

        }
    }
}
