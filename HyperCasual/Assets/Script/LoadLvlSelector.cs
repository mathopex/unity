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
            if (PlayerPrefs.GetInt("quetelvl01") == 1)
            {
   
                StartCoroutine(LoadLvl());
                return;
            }

            StartCoroutine(Chargement()); 
        }
    }


    private IEnumerator Chargement()
    {
        text.SetActive(true);
        GameObject.Find("Charactere").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GameObject.Find("Charactere").GetComponent<Rigidbody2D>().simulated = false;
        GameObject.Find("Charactere").GetComponent<CircleCollider2D>().enabled = false;
        GameObject.Find("Charactere").GetComponent<PlayerMouvement>().enabled = false;
        GameObject.Find("Charactere").GetComponent<PlayerMouvement>().animator.SetFloat("Velocity", 0);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }

    private IEnumerator LoadLvl()
    {
        GameObject.Find("Charactere").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GameObject.Find("Charactere").GetComponent<Rigidbody2D>().simulated = false;
        GameObject.Find("Charactere").GetComponent<CircleCollider2D>().enabled = false;
        GameObject.Find("Charactere").GetComponent<PlayerMouvement>().enabled = false;
        GameObject.Find("Charactere").GetComponent<PlayerMouvement>().animator.SetFloat("Velocity", 0);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);

    }
}
