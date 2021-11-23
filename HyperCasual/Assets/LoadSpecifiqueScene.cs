using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSpecifiqueScene : MonoBehaviour
{
    private bool isInRange = false;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene(2);
            SceneLoading();
        }
    }


    private void SceneLoading()
    {
        if(isInRange)
        {
            SceneManager.LoadScene(2);
            isInRange = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player") )
        {
            isInRange = true;
        }
    }


}
