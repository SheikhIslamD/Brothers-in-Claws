using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public Transform spawnPoint; 
    public int numberOfEnemiesToSpawnAtOnce = 1; 
    public float spawnRadius = 5f; 
    public float spawnInterval = 5f; 
    public int totalEnemiesToSpawn = 20; 

    private int enemiesSpawned = 0; 

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (enemiesSpawned < totalEnemiesToSpawn) 
        {
            for (int i = 0; i < numberOfEnemiesToSpawnAtOnce; i++)
            {
                if (enemiesSpawned >= totalEnemiesToSpawn)
                {
                    break;
                }

                
                Vector3 randomPosition = spawnPoint.position + Random.insideUnitSphere * spawnRadius;
                NavMeshHit hit;

                
                if (NavMesh.SamplePosition(randomPosition, out hit, spawnRadius, NavMesh.AllAreas))
                {
                    
                    Instantiate(enemyPrefab, hit.position, Quaternion.identity);
                    enemiesSpawned++; 
                    Debug.Log($"Spawned enemy at: {hit.position}. Total spawned: {enemiesSpawned}");
                }
                else
                {
                    Debug.Log("Spawn position not valid, retrying...");
                    i--; 
                }
            }

            yield return new WaitForSeconds(spawnInterval);
        }

        Debug.Log("All enemies have been spawned.");
    }
}
