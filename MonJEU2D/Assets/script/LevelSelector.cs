
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButton;

    public int levelReach;

    public static LevelSelector instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("il y a plus d'un instance de LevelSelector dans cette scene");
            return;
        }

        instance = this;
    }

        private void Start()
    {

        levelReach = PlayerPrefs.GetInt("levelReach", 0);

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


