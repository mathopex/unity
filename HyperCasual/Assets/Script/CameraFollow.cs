using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public float timeOffSet;
    public Vector3 posOffSet;

    private Vector3 velocity;


    void Update()
    {
        //si le joueur est mort on desective le script de camera follow
        if (PlayerDeath.instance.isDie)
        {
            GetComponent<CameraFollow>().enabled = false;
            
        }

        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffSet, ref velocity, timeOffSet);

    }


}
