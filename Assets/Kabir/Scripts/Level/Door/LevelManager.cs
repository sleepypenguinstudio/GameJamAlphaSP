using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static int levelNo;

    private void Start()
    {
        levelNo++;
        Debug.Log("Level No    "+levelNo);
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SceneManager.LoadScene(0);
        //}
    }
}
