using UnityEngine;
public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int numberOfEnemies;
    private int enemySize;
    private float groundSize;
    private float floorSize;
    public EnemySpawn(GameObject enemyPrefab, int numberOfEnemies, int enemySize, int floorSize)
    {
        this.numberOfEnemies = numberOfEnemies;
        this.enemySize = enemySize;
        this.enemyPrefab = enemyPrefab;
        this.floorSize = floorSize;
        
    }


    public void Spawn()
    {
        groundSize = floorSize / 2;
        for (int i = 0; i < numberOfEnemies; i++)
        {
            
            float randomX = Random.Range(-enemySize, enemySize);
            float randomZ = Random.Range(-enemySize, enemySize);

            Vector3 enemyPosition = new Vector3(randomX, 0f, randomZ);
            Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
            if (Mathf.Abs(enemyPosition.x) <= groundSize && Mathf.Abs(enemyPosition.z) <= groundSize)
            {
                Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
            }
        }
    }
}
