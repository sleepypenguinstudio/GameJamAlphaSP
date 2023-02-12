using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;
public class NextLevel : MonoBehaviour
{


    [SerializeField] private int sceneToLoad;
    //tarterAssetsInputs starterAssetsInputs;

    
    private void OnTriggerStay(Collider other)
    {
        //starterAssetsInputs = other.GetComponent<StarterAssetsInputs>();

        if (other.tag == "PLayer")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                ChangeLevel();

            }
        }

        

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
   

}
