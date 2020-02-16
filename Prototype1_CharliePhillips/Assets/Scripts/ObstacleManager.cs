using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;

    private void Start()
    {
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        for (int i = 0; i < 100; i++)
        {
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            float xPos = Random.Range(-GetComponent<Collider>().bounds.size.x, GetComponent<Collider>().bounds.size.x);
            float yPos = Random.Range(-GetComponent<Collider>().bounds.size.y, GetComponent<Collider>().bounds.size.y);
            float zPos = Random.Range(-GetComponent<Collider>().bounds.size.z, GetComponent<Collider>().bounds.size.z);

            Instantiate(obstaclePrefabs[obstacleIndex], new Vector3(xPos, yPos, zPos), obstaclePrefabs[obstacleIndex].transform.rotation);
        }
    }

    private void Update()
    {

    }


}
