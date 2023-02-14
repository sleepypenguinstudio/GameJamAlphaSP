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
        if (other.CompareTag("Player")) { 

        if (Input.GetKeyDown(KeyCode.E))
        {
            
            ChangeLevel();
               LevelManager.levelNo++;

            }
    }
      

        

    }
    public void ChangeLevel() {
        AudioController.instance.PlaySound(AudioController.instance.levelCompleteSound);
        PlayerPrefs.SetInt("levelNo", LevelManager.levelNo);
        if (LevelManager.levelNo < 4)
        {
            sceneToLoad = 1;
            SceneManager.LoadScene(sceneToLoad);
        }
        else if (LevelManager.levelNo == 4)
        {
            sceneToLoad = 2;
            SceneManager.LoadScene(sceneToLoad);
        }
        else if(LevelManager.levelNo  > 5 && LevelManager.levelNo  <9)
        {
            sceneToLoad = 3;
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            sceneToLoad = 5;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
   

}
