using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq; 

public class Settings : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Slider general, effect, menu, musique;
    public AudioMixer audioMixer;
    Resolution[] resolutions;


    private void Start()
    {

        audioMixer.GetFloat("Musique", out float musicValueForSlider);
        musique.value = musicValueForSlider;

        audioMixer.GetFloat("Effet", out float effetValueForSlider);
        effect.value = effetValueForSlider;

        audioMixer.GetFloat("Master", out float generalValueForSlider);
        general.value = generalValueForSlider;

        audioMixer.GetFloat("Menu", out float menuValueForSlider);
        menu.value = menuValueForSlider;

        //permet de reup toutes mes resolution, et de filtré celle qui le sont deja
        //est d'en affciher qu'une seule
        resolutions = Screen.resolutions.Select(resolutions => new Resolution
        {
            width = resolutions.width,
            height = resolutions.height,
        }).Distinct().ToArray();

        resolutionDropdown.ClearOptions();

        //creatiopn de la liste des resolution 
        List<string> option = new List<string>();

        int currentResolutionInddex = 0;

        //boucle parcourant les resolution disponible et les ajouté a la liste
        for (int i = 0; i < resolutions.Length; i++)
        {
            string options = resolutions[i].width + "X" + resolutions[i].height;
             option.Add(options);

            //on verrifi si la resolution cherché et la même que celle du joueur
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionInddex = i;
            }
        }

        //ajout des resolution trouver
        resolutionDropdown.AddOptions(option);
        //selectionne la resolution du joueu
        resolutionDropdown.value = currentResolutionInddex;
        //on met a jour la list
        resolutionDropdown.RefreshShownValue();

        Screen.fullScreen = true;

        
    }



    public void SetEffet(float volume)
    {
        audioMixer.SetFloat("Effet", volume);
    }
    public void SetMenu(float volume)
    {
        audioMixer.SetFloat("Menu", volume);
    }
    public void SetMusique(float volume)
    {
        audioMixer.SetFloat("Musique", volume);  
        Debug.Log("je suis general");
    }

    public void SetFullScreen()
    {

     
 

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resoution = resolutions[resolutionIndex];
        Screen.SetResolution(resoution.width, resoution.height, Screen.fullScreen);
    }

}
