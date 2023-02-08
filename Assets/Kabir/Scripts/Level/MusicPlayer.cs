using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] levelSongs;
    private AudioSource audioSource;
    private int levelIndex;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = levelSongs[levelIndex];
        audioSource.Play();
    }

    public void PlaySongForLevel(int level)
    {
        levelIndex = level;
        audioSource.clip = levelSongs[levelIndex];
        audioSource.Play();
    }

    public void StopSong()
    {
        audioSource.Stop();
    }
}
