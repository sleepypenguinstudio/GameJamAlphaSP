using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{


    [SerializeField] private int sceneToLoad;
    private void OnTriggerStay(Collider other)
    {
        
      

        

    }
    public void ChangeLevel() {
        if (LevelManager.levelNo < 4)
        {
            sceneToLoad = 0;
            SceneManager.LoadScene(sceneToLoad);
        }
        else if (LevelManager.levelNo == 4)
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeLevel();
        }
    }

}
