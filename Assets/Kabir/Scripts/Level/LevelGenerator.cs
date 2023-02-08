using System.Collections;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Transform[] playerSpawnPoints;
    public Transform[] exitPoints;

    private void Start()
    {
        int randomPlayerSpawnIndex = Random.Range(0, playerSpawnPoints.Length);
        int randomExitIndex = Random.Range(0, exitPoints.Length);

        Transform playerSpawnPoint = playerSpawnPoints[randomPlayerSpawnIndex];
        Transform exitPoint = exitPoints[randomExitIndex];

        // Place the player at the random player spawn point
        // Replace "player" with your player object
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = playerSpawnPoint.position;

        // Place the exit at the random exit point
        // Replace "exit" with your exit object
        GameObject exit = GameObject.FindWithTag("Exit");
        exit.transform.position = exitPoint.position;
    }
}
