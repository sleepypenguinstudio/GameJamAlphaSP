using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public AudioSource source;

    #region AudioClipsVar

    public AudioClip levelCompleteSound;
    public AudioClip doorBreakSound;
    public AudioClip elevatorDingSound;
    public AudioClip enemyDeathSound;
    public AudioClip enemyFootstepSound;
    public AudioClip enemyInjurySound;
    public AudioClip enemyLaughingSound;
    public AudioClip gameOverSound;
    public AudioClip gunInstantiate;
    public AudioClip gunDropSound;
    public AudioClip shootPistolSound;
    public AudioClip shootSmgSound;
    public AudioClip shootShotgunSound;
    public AudioClip kickSound;
    //public AudioClip menuBGSound;
    public AudioClip menuSelectSound;
    public AudioClip playerDeathSound;
    public AudioClip playerFootstepSound;
    public AudioClip playerHurtSound;
    public AudioClip playerLowHealthSound;
    public AudioClip reloadPistolSound;
    public AudioClip reloadSmgSound;
    public AudioClip realoadShotgunSound;
    public AudioClip glassShatterSound;
    public AudioClip electricSparkSound;
    public AudioClip bulletHitSound;
    public AudioClip sfxSliderSound;
    public AudioClip[] levelSong; 
    
    #endregion
    
    
    public static AudioController instance;
    
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        if (source == null)
        {
            source = GetComponent<AudioSource>();
        }

        PlaySound(doorBreakSound);
        PlayLevelSong(4);
    }

    void Update()
    {
        
    }


    #region SoundPlay

    
    public void PlaySound(AudioClip soundToBePlayed)
    {
        source.PlayOneShot(soundToBePlayed);
        source.volume = 1f;
    }


    public void PlayLevelSong(int levelNumber)
    {
        source.clip = levelSong[levelNumber];
        source.Play();


    }
    
    #endregion
    
    
    

}
