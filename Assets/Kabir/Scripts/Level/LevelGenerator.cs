using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int floorSize = 10;
    public GameObject floorPrefab;
    public GameObject wallPrefab;





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

        //PrefabSpawn prefabSpawn = new PrefabSpawn(prefab, prefabSize, floorSize, numberOfPrefabs);
        //prefabSpawn.Spawn();

        //EnemySpawn enemySpawn = new EnemySpawn(enemyPrefabs, enemyPositions, spawnInterval);
        //enemySpawn.Spawn();
    }
}