using UnityEngine;
public class FloorSpawn : MonoBehaviour
{
    public GameObject floorPrefab;
    private int floorSize;

    public FloorSpawn(int floorSize, GameObject floorPrefab)
    {
        this.floorSize = floorSize;
        this.floorPrefab = floorPrefab;
    }

    public void Spawn()
    {
        for (int x = -floorSize; x <= floorSize; x++)
        {
            for (int z = -floorSize; z <= floorSize; z++)
            {
                Vector3 floorPosition = new Vector3(x, 0f, z);
                Instantiate(floorPrefab, floorPosition, Quaternion.identity);
            }
        }
    }
}
