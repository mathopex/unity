
using UnityEngine;
using UnityEngine.UI;   
   

    /* Gestion de la barre de vie graphiquement */
public class HealthBarEnemie : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    //methode qui reinitialise la vie max du joueur
    public void setMaxHealth ( int health)
    {
        // 100 points de vie 
        slider.maxValue = health;

        //valeur de point de vie 
        slider.value = health;

        //remplissage de l'image barre de vie 
        fill.color = gradient.Evaluate(1f);
    }

    //methode qui applique un certain nombre de point de vie (+ ou -)
    public void SetHealth( int health)
    {
        slider.value = health;

        //transforme la veleur de 0 a 100 en  0 a 1 pour le gradient
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }


}


