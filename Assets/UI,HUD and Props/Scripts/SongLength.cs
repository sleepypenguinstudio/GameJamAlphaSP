using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SongLength : MonoBehaviour
{
    public AudioClip song;

    private void Start()
    {
        float songLength = song.length;
        Debug.Log("Song length: " + songLength + " seconds");
    }
}

