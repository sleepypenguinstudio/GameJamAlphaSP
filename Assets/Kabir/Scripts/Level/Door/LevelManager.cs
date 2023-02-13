using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static int levelNo;

    AudioSource levelAudioSource;
    [SerializeField] TMP_Text levelText;

    private void Start()
    {
        levelAudioSource = GetComponent<AudioSource>();
        
        Debug.Log("Level No    "+levelNo);
        PlayLevelSong(levelNo);
        LevelChangeText();
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
       levelAudioSource.clip = AudioController.instance.levelSong[levelNumber];

        Debug.LogError("Level No ---" + levelNo+ " song name : "+ AudioController.instance.levelSong[levelNumber].name);
       levelAudioSource.Play();



   }


   public void LevelChangeText()
    {
        if (levelText) {
            levelText.text = "Level: " + levelNo;
        }
    }

}
