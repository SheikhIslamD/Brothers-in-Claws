using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class DraftingUI : MonoBehaviour
{

    public Transform spawnPoint;
    public float spawnRadius = 0.1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAlly(GameObject prefabToSpawn)
    {
        if(prefabToSpawn != null && spawnPoint !=null)
        {

            Vector3 navMeshPosition = spawnPoint.position + Random.insideUnitSphere * spawnRadius;
            NavMeshHit check; 

            if (UnityEngine.AI.NavMesh.SamplePosition(navMeshPosition, out check, spawnRadius, UnityEngine.AI.NavMesh.AllAreas)) 
            {
                Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
            }
            else
            {
                Debug.Log("fail");
            }
            
        }
        
    }
}
