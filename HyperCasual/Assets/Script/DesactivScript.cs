using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivScript : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("Charactere").GetComponent<PlayerDeath>().enabled = false;
        GameObject.Find("Charactere").GetComponent<PlayerHealth>().enabled = false;
    }
}
