using System;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int currentLevel = 0;
    public GameObject[] levels;




    private void Start()
    {
        LoadLevel(currentLevel);
    }

    private void LoadLevel(int levelIndex)
    {
        if (levelIndex >= 0 && levelIndex < levels.Length)
        {
            // Deactivate current level
            if (currentLevel >= 0 && currentLevel < levels.Length)
            {
                levels[currentLevel].SetActive(false);
            }

            // Activate new level
            currentLevel = levelIndex;
            levels[currentLevel].SetActive(true);
        }
    }


}