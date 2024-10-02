using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyType
    {
        public GameObject enemyPrefab;     
        public int numberOfEnemies;        
        public float spawnInterval = 1f;    
        public Transform spawnPoint;        
    }

    [System.Serializable]
    public class Wave
    {
        public List<EnemyType> enemyTypes;
        public float timeBetweenWaves = 5f; 
    }

    public List<Wave> waves;
    private int currentWaveIndex = 0;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (currentWaveIndex < waves.Count)
        {
            Wave currentWave = waves[currentWaveIndex];

            foreach (EnemyType enemyType in currentWave.enemyTypes)
            {
                for (int i = 0; i < enemyType.numberOfEnemies; i++)
                {
                    Vector3 spawnPosition = enemyType.spawnPoint.position;
                    NavMeshHit hit;

                    // Ensure the spawn position is on the NavMesh
                    if (NavMesh.SamplePosition(spawnPosition, out hit, 1.0f, NavMesh.AllAreas))
                    {
                        Instantiate(enemyType.enemyPrefab, hit.position, Quaternion.identity);
                    }
                    else
                    {
                        i--; // Retry spawning if not on the NavMesh
                    }

                    yield return new WaitForSeconds(enemyType.spawnInterval);
                }
            }

            currentWaveIndex++;

            if (currentWaveIndex < waves.Count)
            {
                yield return new WaitForSeconds(currentWave.timeBetweenWaves);
            }
        }
    }
}
