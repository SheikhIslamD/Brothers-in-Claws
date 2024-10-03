using UnityEngine;
using UnityEngine.UI;

public class DraftingButton : MonoBehaviour
{
    public Drafting Drafting;
    public bool isSelected;
    //highlight color
    Image colorHighlight;

    public BattleUI battleUI;

    public bool pelicannonactive;
    public bool shelldonactive;
    public bool prawnactive;

    public GameObject pelicannonButton;
    public GameObject shelldonButton;
    public GameObject prawnButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        colorHighlight = GetComponent<Image>();
        colorHighlight.color = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Drafting.crewSelected.Count);
    }

    public void Select()
    {
        if (!isSelected)
        {
            if (Drafting.crewSelected.Count < Drafting.crewMax)
            {
                Drafting.crewSelected.Add(this.gameObject.name);
                colorHighlight.color = Color.green;
                isSelected = true;
            }
            else
            {
                Debug.Log("Crew is full!!");
            }
        }
        else
        {
            Drafting.crewSelected.Remove(this.gameObject.name);
            colorHighlight.color = Color.gray;
            isSelected = false;
        }
    }

    public void pelicannon()
    {
        if (pelicannonactive)
        {
            pelicannonactive = false;
            pelicannonButton.SetActive(false);
        }
        else 
        {
            pelicannonactive = true;
            pelicannonButton.SetActive(true);
        }
        
    }
    public void shelldon()
    {
        if (shelldonactive)
        {
            shelldonactive = false;
            shelldonButton.SetActive(false);
        }
        else
        {
            shelldonactive = true;
            shelldonButton.SetActive(true);
        }
        
    }
    public void prawn()
    {
        if (prawnactive)
        {
            prawnactive = false;
            prawnButton.SetActive(false);
        }
        else
        {
            prawnactive = true;
            prawnButton.SetActive(true);
        }
    }
}
