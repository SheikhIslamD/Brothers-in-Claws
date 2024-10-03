using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.AI;

public class Drafting : MonoBehaviour
{
    //should this script be a singleton? probably i think
    [Header("Battle Spawning")]
    public Transform spawnPoint;
    public float spawnRadius = 0.1f;
    public GameObject[] allyCrewmatesPrefabs; //every ally unit prefab should be assigned here
    public GameObject[] currentCrewmates; //the crewmate selection that's locked in for battle (using array since it will not change after draft is over)
    public BattleUI battleUI;

    [Header("Pre-Battle Drafting")]
    public GameState gameState;
    public List <string> crewSelected; //how many crewmates are currently selected/highlighted (using list to allow adding/removing)
    public int crewMax = 3; //how many crewmates are allowed to be chosen for the current fight
    
// This whole section is for dynamic crew selection and limited crewmates
// if/when we switch from PvZ style to unique party members style, this should auto-populate with buttons that pass the part member's data to the battle menu
    //public GameObject[] crewSpots; //all the spots in the UI for crew to be picked from
    //public GameObject crewSpot; //prefab of a crew selectable spot
    //public static List <GameObject> crewTotal; //how many crewmates the player has in total, update across the whole game

    void OnEnable()
    {
        //later in the game, this should populate the array of selectable units with the actual player's total crew
/*        foreach (var crew in crewTotal) 
        {
            Instantiate(crewSpot, new Vector3 (x,y))
        }*/
    }

    // Update is called once per frame
    public void EndDraft()
    {
        /*        //tell it to stop anything needed to stop here
                //this pass crewmates from Selected list to Battle UI array
                //Button object names in heirarchy MUST be named the same as the crewmate prefab they represent
                foreach (string crew in crewSelected) 
                {
                    //checks through our prefab list of crewmates to see which one matches the name of the selected button
                    //then assigns it into the currentCrewmates array for use in Battle UI
                    foreach (GameObject crewPrefab in allyCrewmatesPrefabs)
                    {
                        Debug.Log(crewPrefab.name);
                        if (crewPrefab.name == crew)
                        {
                            //uses the positions in the list to assign prefabs in same order in the array
                            currentCrewmates[crewSelected.IndexOf(crew)] = crewPrefab;
                            Debug.Log("corresponding prefab assigned");
                        }
                        else
                        {
                            //return;
                        }
                    }
                    //return;
                    Debug.Log("checking list");
                }
                //after the prefabs are found based on the selected crewmates, should assigns the prefabs for SpawnAlly()'s prefabToSpawn variable for each button
                //assigning corresponding sprites
                battleUI.AssignButtonSprites();
                Debug.Log(currentCrewmates.Length);*/
/*
        foreach (string crew in crewSelected)
        {
            if (crew == "Peli Cannon")
            {
                battleUI.pelicannonButton.SetActive(true);
            }
            else
                return;
            if (crew == "Shelldon")
            {
                battleUI.shelldonButton.SetActive(true);
            }
            else
                return;
            if (crew == "Prawn")
            {
                battleUI.prawnButton.SetActive(true);
            }
            else
                return;
        }*/
    }

/*    //ally spawning function for the Battle UI buttons to use
    public void SpawnAlly()
    {
        GameObject prefabToSpawn = currentCrewmates[buttonNumber.num)];
        if (prefabToSpawn != null && spawnPoint != null)
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

    }*/
}
