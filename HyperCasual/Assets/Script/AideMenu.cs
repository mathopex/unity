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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            menuAide.SetActive(true);
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
