using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private int sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        if (PlayerPrefs.GetInt("levelNo") == 0)
        {
            SceneManager.LoadScene(1);
        }
        else {
            if (PlayerPrefs.GetInt("levelNo") < 4)
            {
                sceneToLoad = 0;
                SceneManager.LoadScene(sceneToLoad);
            }
            else if (PlayerPrefs.GetInt("levelNo") == 4)
            {
                sceneToLoad = 1;
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                sceneToLoad = 2;
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }



    public void QuitGame()
    {
        Application.Quit();
    }
}
