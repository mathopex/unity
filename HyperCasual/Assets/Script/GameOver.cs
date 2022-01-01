using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject fond, defaite;
    public AudioClip sound;
    public static GameOver instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning(" il y a plus d'une instance de GameOverManager dans le jeu");
            return;
        }

        instance = this;
    }



    public void OpenPlayerDeath()
    {
        fond.SetActive(true);
        StartCoroutine(Fade());
           
       
    }


    private IEnumerator Fade()
    {
        yield return new WaitForSeconds(1.12f);
        defaite.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        AudioManager.instance.PlayClipAt(sound, transform.position);
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(1);
    }

}
