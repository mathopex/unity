using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public Dropdown resolutionDropdown;
    public AudioMixer audioMixer;
    Resolution[] resolutions;

    public Slider musicSlider;
    public Slider soundSlider;

    private void Start()
    {

        audioMixer.GetFloat("Musique", out float musicValueForSlider);
        musicSlider.value= musicValueForSlider;

        audioMixer.GetFloat("Sound", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;

        //permet de recupéré toutes les resolutions, et de filtré celle qui sont deja recupéré et d'en affiché qu'une seule
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropdown.ClearOptions();


        //creation d'une liste pour les resolution
        List<string> option = new List<string>();

        int currentResolutionIndex = 0;

        //bloucle parcouran des resolutions disponible  et de les ajouté a la liste
        for (int i = 0; i < resolutions.Length; i++)
        {
            string options = resolutions[i].width + "x" + resolutions[i].height;
            option.Add(options);

            // on verrifie si la resolution cherché et la meme que la resolution du joueur
            if ( resolutions[i].width ==  Screen.width && resolutions[i].height == Screen.height)
            {
                //on affecte la valeur identique a currentResoloutionindex
                currentResolutionIndex = i;
            }
        }

        
        //ajout des resolutions dans le menu deroulant
        resolutionDropdown.AddOptions(option);
        //on selectionne la resolution du joueur
        resolutionDropdown.value = currentResolutionIndex;
        // on met a jour la liste deroulante 
        resolutionDropdown.RefreshShownValue();

        Screen.fullScreen = true;

   
    }

    // permet la modification du son in game
   public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Musique", volume); 
    }

    public void SetSound(float volume)
    {
        audioMixer.SetFloat("Sound", volume);
    }

    // active ou desactive le mode plein ecran
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    // opn applique la resolution selectionné par le joueur a l'ecran
    public void SetResolution( int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    
    }



}
