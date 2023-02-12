using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static int levelNo;
    public TMP_Text levelText;

    private void Start()
    {
        levelNo++;
        Debug.Log("Level No    "+levelNo);

        ChangeLevelText();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void ChangeLevelText()
    {
        levelText.text = "Level "+ levelNo.ToString();
    }
}
