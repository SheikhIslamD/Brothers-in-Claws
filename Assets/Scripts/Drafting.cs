using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Drafting : MonoBehaviour
{
    public GameState gameState;
    //how many crewmates are allowed on-field for the current fight
    public int crewMax = 10;
    //how many crewmates are currently selected/highlighted
    public List <GameObject> crewSelected;
    //all the spots in the UI for crew to be picked from
    public GameObject[] crewSpots;

    //prefab of a crew selectable spot
    //public GameObject crewSpot;

    //how many crewmates the player has in total, update across the whole game
    public static List <GameObject> crewTotal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        //later in the game, this should populate the array of selectable units with the actual player's total crew
/*        foreach (var crew in crewTotal) 
        {
            Instantiate(crewSpot, new Vector3 (x,y))
        }*/
    }

    // Update is called once per frame
    void EndDraft()
    {
        //tell it to stop anything needed to stop here
    }
}
