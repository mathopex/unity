using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq; 

public class Settings : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public Slider effect, menu, musique;
    Resolution[] resolutions;

    public float volume;


    private void Start()
    {

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

    public void SetFullScreen()
    {
     
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resoution = resolutions[resolutionIndex];
        Screen.SetResolution(resoution.width, resoution.height, Screen.fullScreen);
    }

}
