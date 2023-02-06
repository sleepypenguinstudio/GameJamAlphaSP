using UnityEngine;
public class PrefabSpawn: MonoBehaviour
{
    public GameObject prefab;
    public float spawnRadius;
    private float groundSize;
    private float floorSize;
    private int prefabSize;

    public PrefabSpawn(GameObject prefab, int prefabSize, int floorSize)
    {
        this.prefab = prefab;
        this.floorSize = floorSize;
        this.prefabSize = prefabSize;
    }

    public void Spawn()
    {
        groundSize = floorSize / 2;
        for (int i = 0; i < 10; i++)
        {

            float randomX = Random.Range(-prefabSize, prefabSize);
            float randomZ = Random.Range(-prefabSize, prefabSize);

            Vector3 prefabPosition = new Vector3(randomX, 0f, randomZ);
            Instantiate(prefab, prefabPosition, Quaternion.identity);
            if (Mathf.Abs(prefabPosition.x) <= groundSize && Mathf.Abs(prefabPosition.z) <= groundSize)
            {
                Instantiate(prefab, prefabPosition, Quaternion.identity);
            }
        }
    }
}