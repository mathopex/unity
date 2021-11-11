using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLvlSelector : MonoBehaviour
{
    public GameObject text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Chargement());
        }
    }


    private IEnumerator Chargement()
    {
        text.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("LevelSelector");
    }
}
