using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SongLength : MonoBehaviour
{
    public AudioClip song;

    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.clip = song;
        audioSource.volume= 1;
        audioSource.Play();
        Debug.Log("aschi");
    }
    private void Update()
    {
        Debug.Log(audioSource.isPlaying);
    }
}

