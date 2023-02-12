using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{

        //    RestartGame();
        //}
    }
    public void NewGame()
    {
        // Load the first level of the game.
        SceneManager.LoadScene("_level1");
    }
    public void RestartGame()
    {
       LevelManager.levelNo--;
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0;
        // Add any additional code for displaying a "game over" message or UI here.
    }
}
