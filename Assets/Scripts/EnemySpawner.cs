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
        public float spawnRadius = 5f;      
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
                    Vector3 randomPosition = enemyType.spawnPoint.position + Random.insideUnitSphere * currentWave.spawnRadius;
                    NavMeshHit hit;

                    if (NavMesh.SamplePosition(randomPosition, out hit, currentWave.spawnRadius, NavMesh.AllAreas))
                    {
                        Instantiate(enemyType.enemyPrefab, hit.position, Quaternion.identity);
                    }
                    else
                    {
                        i--; 
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
