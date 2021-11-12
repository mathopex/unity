using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AideMenu : MonoBehaviour
{
    public GameObject menuAide;
    public GameObject boutonClose;


    private void Start()
    {
        StartCoroutine(LoadMenuAide());
    }

    void Update()
    {
         //si il est deja actif on le desactive
        if (menuAide.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                menuAide.SetActive(false);
            }

        }
        else
        {
            //si il est pas actif on l'active 
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                menuAide.SetActive(true);
            }

        }

       

    }

    private IEnumerator LoadMenuAide()
    {
        yield return new WaitForSeconds(1.5f);
        menuAide.SetActive(true);
        yield return new WaitForSeconds(5f);
        boutonClose.SetActive(true);

    }


    public void Close()
    {
        menuAide.SetActive(false);
    }


 
}
