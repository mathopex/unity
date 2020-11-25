using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;


public class PLayerCollision : MonoBehaviour
{ 
    private bool isInvincible = false;
    private bool canInInstantiate = true;
    public AudioClip audioHit, audioCoin;
    private AudioSource audioSource;
    public SkinnedMeshRenderer rend;

    public GameObject pickUpEffect;
    public GameObject mobEffect;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider trigger)
    {
        //ramasse les pieces
        if (trigger.CompareTag("coin"))
        {
            audioSource.PlayOneShot(audioCoin);
            GameObject go = Instantiate(pickUpEffect, trigger.transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
            Destroy(trigger.gameObject);
            PlayerInfo.pI.GetCoin();

        }

        //destruction de l'enemie
        if (trigger.CompareTag("Carapace") && canInInstantiate)
        {
            canInInstantiate = false;
            audioSource.PlayOneShot(audioHit);
            iTween.ScaleFrom(trigger.gameObject, new Vector3(0, 50, 0), 10f);
            GameObject go = Instantiate(mobEffect, trigger.transform.position, Quaternion.identity);
            Destroy(go, 0.8f);
            Destroy(trigger.gameObject);
            StartCoroutine("ResetInstantiate");
        }

        //activation de la cam1
        if (trigger.CompareTag("Cam1"))
        {

            cam1.SetActive(true);
        }
        if (trigger.CompareTag("cam2"))
        {

            cam2.SetActive(true);
        }
        if (trigger.CompareTag("cam3"))
        {

            cam3.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cam1"))
        {
            cam1.SetActive(false);
        }
        if (other.CompareTag("cam2"))
        {
            cam2.SetActive(false);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemi" && !isInvincible)
        {
            PlayerInfo.pI.SetHealth(-1);
            isInvincible = true;
            StartCoroutine("ResetInvincible");
        }


    }

    IEnumerator ResetInstantiate()
    {
        yield return new WaitForSeconds(0.8f);
        canInInstantiate = true;
    }

    IEnumerator ResetInvincible()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.2f);
            rend.enabled = !rend.enabled;
        }
        yield return new WaitForSeconds(0.2f);
        rend.enabled = true;
        isInvincible = false;
    }
}


