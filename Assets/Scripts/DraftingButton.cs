using UnityEngine;
using UnityEngine.UI;

public class DraftingButton : MonoBehaviour
{
    public Drafting Drafting;
    public bool isSelected;
    //highlight color
    Image colorHighlight;
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
                Drafting.crewSelected.Add(this.gameObject);
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
            Drafting.crewSelected.Remove(this.gameObject);
            colorHighlight.color = Color.gray;
            isSelected = false;
        }
    }
}
