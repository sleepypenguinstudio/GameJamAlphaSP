using UnityEngine;
public class WallSpawn: MonoBehaviour
{
    public GameObject wallPrefab;
    private int wallSize;

    public WallSpawn(int wallSize, GameObject wallPrefab)
    {
        this.wallSize = wallSize;
        this.wallPrefab = wallPrefab;
    }

    public void Spawn()
    {
        for (int x = -wallSize; x <= wallSize; x++)
        {
            for (int z = -wallSize; z <= wallSize; z++)
            {
                if (x == -wallSize || x == wallSize || z == -wallSize || z == wallSize)
                {
                    Vector3 wallPosition = new Vector3(x, 0f, z);
                    Instantiate(wallPrefab, wallPosition, Quaternion.identity);
                }
            }
        }
    }
}
