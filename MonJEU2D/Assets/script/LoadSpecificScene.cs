
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Runtime.Serialization;

public class LoadSpecificScene : MonoBehaviour
{

    public string scenneName;
    

    private Animator fadeSystem;
    private Text interactUI;
    private MovePlayer movePlayer;
    private bool isDoor;
    public static LoadSpecificScene instance;
    public int idCurrentScene;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("il y a plus d'un instance de LoadSpecificScene dans cette scene");
            return;
        }

        instance = this;

        fadeSystem = GameObject.FindGameObjectWithTag("Fade").GetComponent<Animator>();
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    private void Update()
    {
        if (isDoor && Input.GetKeyDown(KeyCode.F))
        {

            StartCoroutine(loadNextScene());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDoor = true;
            interactUI.enabled = true;
        }
     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isDoor = false;
            interactUI.enabled = false;
        }

    }

    public IEnumerator loadNextScene()
    {
        LoadSaveData.instance.SaveData();
        fadeSystem.SetTrigger("FadeIn");
        interactUI.enabled = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scenneName);

    }
   
}
