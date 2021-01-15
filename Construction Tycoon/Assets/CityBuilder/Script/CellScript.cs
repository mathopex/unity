using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    GameManager gm;
    void Start()
    {
        gm = GameObject.Find("Grid").GetComponent<GameManager>();
    }

    // Update is called once per frame
   
    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }


    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    private void OnMouseUp()
    {

        GameObject go = Instantiate(gm.building, transform.position, Quaternion.Euler(-90,0,0));
        go.name = "Building_" + gameObject.name;
    } 

}

   



