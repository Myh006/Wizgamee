using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign the prefab in the Inspector
    public float spawnInterval = 2.0f; // Time between spawns in seconds
    public float minXPosition = -20.0f;
    public float maxXPosition = 20.0f;

    private float nextSpawnTime;

    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnPrefab();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnPrefab()
    {
        float randomX = Random.Range(minXPosition, maxXPosition);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}