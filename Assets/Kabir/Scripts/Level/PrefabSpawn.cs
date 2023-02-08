using System.Collections;
using UnityEngine;
public class PrefabSpawn : MonoBehaviour
{
    public GameObject[] prefabs;
    Vector3[] prefabPositions;




    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        GameObject[] prefabSpawnPossibilities = GameObject.FindGameObjectsWithTag("prefabSpawnPossibility");
        prefabPositions = new Vector3[prefabSpawnPossibilities.Length];
        for (int i = 0; i < prefabSpawnPossibilities.Length; i++)
        {
            prefabPositions[i] = prefabSpawnPossibilities[i].transform.position;
        }
        int prefabsCount = prefabSpawnPossibilities.Length;
        for (int i = 0; i < prefabsCount; i++)
        {
            int randomPrefabIndex = Random.Range(0, prefabs.Length);
            Instantiate(prefabs[randomPrefabIndex], prefabPositions[i], Quaternion.identity);
        }
    }
}
