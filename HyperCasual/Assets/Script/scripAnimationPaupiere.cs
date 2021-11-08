using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scripAnimationPaupiere : MonoBehaviour
{
    public SpriteRenderer paupierInfGauche;
    public SpriteRenderer paupierInfDroite;
    //public Animator anime;
  


     private void start()
    {
        //anime = GetComponent<Animator>();
    }
    public void ActrivePaupiere()
    {

        paupierInfDroite.enabled = true;
        paupierInfGauche.enabled = true;
    }


    public void desactivepaupiere()
    {
        paupierInfDroite.enabled = false;
        paupierInfGauche.enabled = false;
    }

    
}
