using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterCollision : MonoBehaviour
{

    public GameObject dial;
    public GameObject dialTxt;
    public GameObject dialForgeron;
    public GameObject dialTxtForgeron;
    public GameObject sword;
    public GameObject triggerForgeron;
    public GameObject porteVillage;
    public GameObject triggerInstructeur;
    public GameObject triggerDialogueBoss;
    public GameObject DialQueteBoss;
    public GameObject TxtDialBoss;



    public RectTransform lifebar;

    bool quest = false;

    public int life = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TriggerDialogue")
        {
            dial.SetActive(true);
            dialTxt.GetComponent<TextMeshProUGUI>().text = "Ta dernière epreuve commence, va chercher une épée au pres du forgeron et revien me voir!";
        }
        if (other.gameObject.name == "TriggerDialogueForgeron")
        {
            dialForgeron.SetActive(true);
            dialTxtForgeron.GetComponent<TextMeshProUGUI>().text = "AHHH!! Te voilà je t'attendais ton instructeur ma demander de te donné cette épée forgé avec une essence magique dedans, tu pourras l'utilisé comme catalyseur magique quand tu auras appris" +
                " des sort avec le divineur, bon courage pour ta dernière epreuve. ";

            StartCoroutine("swordActive");
        }

        if (other.gameObject.name == "TriggerDialogueBoss")
        {
            if (!quest)
            {
                dial.SetActive(true);
                dialTxt.GetComponent<TextMeshProUGUI>().text = "Le grand golem de pierre nous a volé l'oeil magique qui voi tout, tue les golem et raporte le moi tu auras une belle recompense ";
            }
            else
            {
                dial.SetActive(true);
                dialTxt.GetComponent<TextMeshProUGUI>().text = "OHHH, tu as reussi merci, voici ta recompense 10 piece d'or";
            }
           
        }

        if(other.gameObject.name == "oeil")
        {
            quest = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "Hand_L")
        {
            life--;
            print(life);
            lifebar.localScale = new Vector3(lifebar.localScale.x - 0.1f, lifebar.localScale.y, lifebar.localScale.z);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "TriggerDialogue")
        {
            dial.SetActive(false);
            triggerInstructeur.SetActive(false);
            triggerForgeron.SetActive(true);
        }
        if(other.gameObject.name == "TriggerDialogueBoss")
        {
            dial.SetActive(false);
            
        }

        if (other.gameObject.name == "TriggerDialogueForgeron")
        {
            dialForgeron.SetActive(false);
            triggerForgeron.SetActive(false);
            porteVillage.SetActive(false);
        }

        
    }

    IEnumerator swordActive()
    {
        yield return new WaitForSeconds(3);
        sword.SetActive(true);
    }


}