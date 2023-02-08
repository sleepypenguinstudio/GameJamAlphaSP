//using System.Collections;
//using UnityEngine;
//public class CubeSpawn : MonoBehaviour
//{
//    public GameObject[] CubePrefabs;
//    Vector3[] prefabPositions = new Vector3[] {
//    new Vector3(50, 0, 30),
//    new Vector3(-70, 0, 23),
//    new Vector3(-67, 0, -42),
//    new Vector3(20, 0, -52),
//    new Vector3(-73, 0, 41)
//    };




//    private void Start()
//    {
//        Spawn();
//    }

//    public void Spawn()
//    {
//        int prefabsCount = prefabPositions.Length;
//        for (int i = 0; i < prefabsCount; i++)
//        {
//            int randomPrefabIndex = Random.Range(0, prefabPositions.Length);
//            Instantiate(CubePrefabs[randomPrefabIndex], prefabPositions[i], Quaternion.identity);
//        }
//    }
//}
