
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButton;
   


    private void Start()
    {

        int levelReach = PlayerPrefs.GetInt("levelReach", 1);

        for (int i = 0; i < levelButton.Length ; i++)
        {
            if( i+1 > levelReach)
            {
                levelButton[i].interactable = false;
            }
            
        }
    }

    public void LoadLevelPassed(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}


