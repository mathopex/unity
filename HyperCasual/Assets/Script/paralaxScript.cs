using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaxScript : MonoBehaviour
{
    private float offset;
    private float speed = 0.25f;
 

    void Update()
    {
        //vitesse de deffilement du fond
        offset = Time.time * speed;
        // on va cherché l'offet de la texture pour le deffilement
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
