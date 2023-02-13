using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject playerPrefab;
    private Vector3[] playerSpawnPoints;


    public static LevelGenerator Instance { get; private set; }

    public GameObject PlayerReference;
    EnemySpawn enemySpawn;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        enemySpawn = GetComponent<EnemySpawn>();
        // Fill the playerSpawnPoints array with the positions of the player spawn points
        GameObject[] playerSpawnPointObjects = GameObject.FindGameObjectsWithTag("playerSpawnPossibility");
        playerSpawnPoints = new Vector3[playerSpawnPointObjects.Length];
        for (int i = 0; i < playerSpawnPointObjects.Length; i++)
        {
            playerSpawnPoints[i] = playerSpawnPointObjects[i].transform.position;
        }

        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        // Pick a random player spawn point
        int randomSpawnPointIndex = Random.Range(0, playerSpawnPoints.Length);
        Vector3 playerSpawnPoint = playerSpawnPoints[randomSpawnPointIndex];

        // Instantiate the player at the chosen spawn point
        PlayerReference = Instantiate(playerPrefab, playerSpawnPoint, Quaternion.identity);
        enemySpawn.StartSpawning();



    }
}
