using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSpecifiqueScene : MonoBehaviour
{
    public bool isInRange = false;
    public GameObject textLvl;


  

    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if( PlayerHealth.instance.heartCount == 0)
            {
                Debug.Log("Tu n'as pas assez de vie !");
            }
            else
            {
                SceneLoading();
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") )
        {
            isInRange = true;
    
        }
    }

    private void SceneLoading()
    {
        if(isInRange)
        {
            SceneManager.LoadScene(textLvl.GetComponent<TextMesh>().text); 
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;

        }

    }





}
