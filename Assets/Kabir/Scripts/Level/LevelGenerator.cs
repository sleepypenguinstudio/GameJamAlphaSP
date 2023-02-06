using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int floorSize = 10;
    public GameObject floorPrefab;
    public GameObject wallPrefab;
    public GameObject enemyPrefab;
    //public Vector3[] enemyPositions;
    public int numberOfEnemies;
    public int prefabSize;
    public int enemySize;
    public GameObject prefab;

    private void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        FloorSpawn floorSpawn = new FloorSpawn(floorSize, floorPrefab);
        floorSpawn.Spawn();

        WallSpawn wallSpawn = new WallSpawn(floorSize, wallPrefab);
        wallSpawn.Spawn();

        PrefabSpawn prefabSpawn = new PrefabSpawn(prefab, prefabSize, floorSize);
        prefabSpawn.Spawn();

        EnemySpawn enemySpawn = new EnemySpawn(enemyPrefab, enemySize, numberOfEnemies, floorSize);
        enemySpawn.Spawn();
    }
}