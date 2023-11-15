using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public Text text;
    public GameObject prefabToSpawn; // Assign the prefab in the Inspector
  

    public int initialAmount = 5;
    public float spawnInterval = 2f;
    public float waveBreakTime = 10f;
    int roundNumber = 1;

    public float minXPosition = -20.0f;
    public float maxXPosition = 20.0f;

    private int enemiesToSpawn;
    private int enemiesSpawned;
    private int enemiesDefeated;
    private float nextSpawnTime;
    private float waveEndTime;


    void Start()
    {
        text.text = "Round: " + roundNumber.ToString();
        
        Debug.Log(gameObject.name);
        enemiesToSpawn = initialAmount;
        nextSpawnTime = Time.time + spawnInterval;
        enemiesSpawned = 0;
        enemiesDefeated = 0;
        StartWave();
    }

    void FixedUpdate()
    {
        if (enemiesSpawned == enemiesToSpawn)
        {
            StartWaveBreak();
        }
        else if (Time.time >= nextSpawnTime)
        {
            if (Time.time >= waveEndTime)
            {
                SpawnPrefab();
                nextSpawnTime = Time.time + spawnInterval;
            }
        }
    }

    private void SpawnPrefab()
    {
        Debug.Log("Enemy Spawned!");
        float randomX = Random.Range(minXPosition, maxXPosition);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        enemiesSpawned++;

    }

    void StartWave()
    {
        Debug.Log("Starting Wave with " + enemiesToSpawn + " enemies.");
    }

    void StartWaveBreak()
    {
        Debug.Log("Wave Break - Next wave in " + waveBreakTime + " seconds.");
        ResetWave();
        waveEndTime = Time.time + waveBreakTime;
    }

    void ResetWave()
    {
        enemiesToSpawn += 5;
        enemiesSpawned = 0;
        enemiesDefeated = 0;
        roundNumber += 1;
        RefreshInterface();
    }

    void RefreshInterface()
    {
        text.text = "Round: " + roundNumber.ToString();
    }

    // Example method to be called when an enemy is defeated
    public void EnemyDefeated()
    {
        enemiesDefeated++;

        // Check if all enemies are defeated
        if (enemiesDefeated == enemiesToSpawn)
        {
            Debug.Log("All enemies defeated!");
        }
    }
}