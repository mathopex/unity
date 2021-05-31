using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMgr : MonoBehaviour
{
    public GameObject hitParticule;
    public Animator anim;
    public int life = 3;


    private void OnTriggerEnter(Collider other)
    {
        // si on est touché par l'épée
        if(other.gameObject.name == "Sword")
        {
            print("AIE j'ai mal !!!!");
            GameObject go = Instantiate(hitParticule, transform.position, Quaternion.identity); // ajoute un effet de hit
            Destroy(go, 2);
            anim.SetTrigger("hited"); // on joue l'anim
            life--;//le monstre perd de la vie 
            
            if( life <= 0)
            {
                life = 0;
                anim.SetTrigger("died");
                GameObject loot = Instantiate(GameManager.Instance.oeil, transform.position, Quaternion.identity);
                loot.name = "oeil";
                CapsuleCollider col = GetComponent<CapsuleCollider>();
                col.enabled = false;
                Destroy(this.gameObject, 3);
            }

        }
    }
}
