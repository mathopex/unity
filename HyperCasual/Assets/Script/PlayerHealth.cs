using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int heartCount;
    public Text heart;
    public bool first = false;

    //timer
    public int countDownValue = 1;
    public Text Time;
    DateTime target;
    public enum _unite { seconde, minutes};
    public _unite unite;
    public bool test = true;


    public static PlayerHealth instance;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de playerHealth");

        }

        instance = this;

        //au lancement du jeu pour la prmeière foi on attribu 3 points de vies au joueur
        if (PlayerPrefs.HasKey("tuto") == false)
        {
            heartCount = 3;
            UpdateTextUI();
            PlayerPrefs.SetInt("heart", heartCount);
        }
    }

    private void Start()
    {
        if(PlayerPrefs.GetInt("heart") > 3)
        {
            heartCount = 3;
            UpdateTextUI();
        }
        else
        {
            heartCount = PlayerPrefs.GetInt("heart");
            UpdateTextUI();
        }
    }

    private void Update()
    {
        
        if (heartCount < 3 && test == true)
        {
            test = false;
            SetCountDown();
            PlayerPrefs.SetInt("heart", heartCount);
        }

    }

    public void AddHeart(int heart)
    {
        if(heart >  3)
        {
            heart = 3;
            
            UpdateTextUI();

            Debug.Log(heart);
        }

        heartCount += heart;
        UpdateTextUI();
     
    }

    public void RemoveHeart(int count)
    {
        if(heartCount < 0)
        {
            heartCount = 0;
            UpdateTextUI();
        }
        heartCount -= count;
        UpdateTextUI();
 
        
    }

    public void UpdateTextUI()
    {
        heart.text = heartCount.ToString();
    }


    public void SetCountDown()
    {
        switch(unite.ToString())
        {
            case "secondes":
                target = DateTime.Now.AddSeconds(countDownValue);
                break;

            case "minutes":
                target = DateTime.Now.AddMinutes(countDownValue);
                break;
        }

        PlayerPrefs.SetString("target", target.ToBinary().ToString());

        ActiveCountDown();
    }


    private void ActiveCountDown()
    {
        if(PlayerPrefs.HasKey("target"))
        {
            target = DateTime.FromBinary(Convert.ToInt64(PlayerPrefs.GetString("target")));
            StartCoroutine(GetDateTimeLeft(target));
        }
  
    }


    private string GetTimeLeft(DateTime targetDate)
    {
        //calcule la difference entre l'heure final et l'heure actuel
        TimeSpan difference = targetDate.Subtract(DateTime.Now);

        //si le resulta de la soustraction est sup a zero, on returne la difference
        if(difference >= TimeSpan.Zero)
        {
            //on formate, au format de la date H:M:S
            return string.Format("{1:D2}:{2:D2}", difference.Hours, difference.Minutes, difference.Seconds);
        }
        else
        {
            return null;
        }
    }

     IEnumerator GetDateTimeLeft(DateTime targetDateTime)
    {

        while(GetTimeLeft(targetDateTime) != null)
        {
            Time.text = GetTimeLeft(targetDateTime);
            yield return new WaitForSeconds(1);
        }

        AddHeart(1);
        test = true;
       
        
    }
}
