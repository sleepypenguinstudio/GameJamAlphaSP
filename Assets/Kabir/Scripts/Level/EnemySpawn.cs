using System.Collections;
using UnityEngine;
public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    Vector3[] enemyPositions = new Vector3[] {
    new Vector3(48, 0, 33),
    new Vector3(-72, 0, 27),
    new Vector3(-66, 0, -40),
    new Vector3(18, 0, -55),
    new Vector3(-70, 0, 40)
    };
    public float spawnInterval = 5f;
    private int spawnCount = 0;
    private int maxSpawnCount = 3;



    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (spawnCount < maxSpawnCount)
        {
            int enemyCount = enemyPositions.Length;
            for (int i = 0; i < enemyCount; i++)
            {
                int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
                Instantiate(enemyPrefabs[randomEnemyIndex], enemyPositions[i], Quaternion.identity);
            }

            spawnCount++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
