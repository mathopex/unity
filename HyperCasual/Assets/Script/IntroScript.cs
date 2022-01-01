using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public Animator animatorTitre, animatorText, animatiorFadeWhite;
    public AudioClip sound;
    public AudioSource audioSource;
    public GameObject titre, WhiteFade,text;

    private bool start = false;

    void Start()
    {
        StartCoroutine(StartIntro());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && start == true)
        {
            audioSource.mute = true;
            StartCoroutine(FadeInWhite());
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

    private IEnumerator FadeInWhite()
    {
        WhiteFade.SetActive(true);
        AudioManager.instance.PlayClipAt(sound, GameObject.Find("AudioManager").transform.position);
        animatiorFadeWhite.Play("FadeInWhite");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(1);

    }

}
