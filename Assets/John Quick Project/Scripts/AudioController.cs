using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    public AudioSource source;

    #region AudioClipsVar
    
    public AudioClip playButtonSound;
    public AudioClip ExitButtonSound;
    public AudioClip levelCompleteSound;
    public AudioClip obstacleHitSound;
    public AudioClip kickSound;
    public AudioClip glassShatterSound;
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public AudioClip bulletHitSound;
    public AudioClip enemyDeathSound;
    public AudioClip playerDeathSound;
    
    
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

    
    #endregion
    
    
    

}
