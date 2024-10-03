using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Unity.VisualScripting;

public class BattleUI : MonoBehaviour
{

    public Transform spawnPoint;
    public float spawnRadius = 0.1f;

    public Drafting Drafting;
    public GameObject[] battleUIButtons;

    public GameObject pelicannonButton;
    public GameObject shelldonButton;
    public GameObject prawnButton;

    public void SpawnAlly(GameObject prefabToSpawn)
    {
        //GameObject prefabToSpawn = Drafting.currentCrewmates[buttonNumber];
        if (prefabToSpawn != null && spawnPoint !=null)
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

/*    public void AssignButtonSprites() 
    { 
        foreach (GameObject button in battleUIButtons) 
        {
            button.GetComponent<Image>().sprite = Drafting.currentCrewmates[System.Array.IndexOf(battleUIButtons, button)].GetComponent<SpriteRenderer>().sprite;
        }
    }*/
}
