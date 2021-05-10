using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "TriggerDialogue")
        {
            dial.SetActive(false);
            triggerInstructeur.SetActive(false);
            triggerForgeron.SetActive(true);
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