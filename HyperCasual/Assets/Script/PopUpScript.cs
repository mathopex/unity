using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    public GameObject popUp;


    

   public void Quitter()
    {
        popUp.SetActive(true);
    }

    public void Oui()
    {
        Application.Quit();
    }

    public void Non()
    {
        popUp.SetActive(false);
    }


}
