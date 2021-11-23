using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{

    public Animator animatorTitre;
    public Animator animatorText;

    public GameObject titre;
    public GameObject text;

    private bool start = false;

    void Start()
    {
        StartCoroutine(StartIntro());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && start == true)
        {
            SceneManager.LoadScene("LevelSelectorV2");
        }
    }


    private IEnumerator StartIntro()
    {
        yield return new WaitForSeconds(0.4f);
        animatorTitre.Play("TitreIntro");
        yield return new WaitForSeconds(1f);
        text.SetActive(true);
        yield return new WaitForSeconds(1.1f);
        animatorTitre.Play("TextIntro");
        start = true;

    }

}
