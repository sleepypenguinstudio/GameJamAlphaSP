using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int levelNo;

    AudioSource levelAudioSource;

    private void Start()
    {
        levelAudioSource = GetComponent<AudioSource>();
        
        Debug.Log("Level No    "+levelNo);
        PlayLevelSong(levelNo);
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SceneManager.LoadScene(0);
        //}
    }

   public void PlayLevelSong(int levelNumber)
   {
       //levelAudioSource.clip = AudioController.instance.levelSong[levelNumber];

        Debug.LogError("Level No ---" + levelNo+ " song name : "+ AudioController.instance.levelSong[levelNumber].name);
       levelAudioSource.Play();


   }

}
