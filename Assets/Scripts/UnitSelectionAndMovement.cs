using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class UnitSelectionAndMovement : MonoBehaviour
{
    private List<GameObject> selectedUnits = new List<GameObject>();
    public LayerMask groundLayer;
    public LayerMask selectableLayer;
    private Rect selectionBox;
    private Vector2 startPos;
    private bool isSelecting = false;
    private bool isBoxValid = false; 
    private float minimumBoxSize = 20f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            isSelecting = true;
            isBoxValid = false;
            ClearSelection();
        }

        if (isSelecting)
        {
            float width = Input.mousePosition.x - startPos.x;
            float height = (Screen.height - Input.mousePosition.y) - startPos.y;

            selectionBox = new Rect(startPos.x, Screen.height - startPos.y, width, height);

            if (Mathf.Abs(width) > minimumBoxSize && Mathf.Abs(height) > minimumBoxSize)
            {
                isBoxValid = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isSelecting = false;

            if (isBoxValid)
            {
                SelectUnitsInBox();
            }
            else
            {
                SelectUnit();
            }
        }

        if (selectedUnits.Count > 0 && Input.GetMouseButtonDown(1))
        {
            MoveUnits();
        }
    }

    void SelectUnit()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, selectableLayer))
        {
            GameObject unit = hit.collider.gameObject;
            if (!selectedUnits.Contains(unit))
            {
                selectedUnits.Add(unit);
                Debug.Log("Selected unit: " + unit.name);

                ChangeSprite(unit, true);
            }
        }
        else
        {
            Debug.Log("No selectable unit hit.");
        }
    }

    void SelectUnitsInBox()
    {
        foreach (GameObject unit in GameObject.FindGameObjectsWithTag("Selectable"))
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(unit.transform.position);
            if (selectionBox.Contains(screenPos))
            {
                if (!selectedUnits.Contains(unit))  
                {
                    selectedUnits.Add(unit);
                    Debug.Log("Selected unit: " + unit.name);
                    
                    ChangeSprite(unit, true);
                }
            }
        }
    }

    void ChangeSprite(GameObject unit, bool isSelected)
    {
        SpriteRenderer spriteRenderer = unit.GetComponent<SpriteRenderer>();
        Unit unitScript = unit.GetComponent<Unit>(); 
        if (spriteRenderer != null && unitScript != null)
        {
            if (isSelected)
            {
                if (unitScript.originalSprite == null)
                {
                    unitScript.originalSprite = spriteRenderer.sprite; 
                }
                spriteRenderer.sprite = unitScript.selectedSprite; 
            }
            else
            {
                spriteRenderer.sprite = unitScript.originalSprite; 
            }
        }
    }

    void MoveUnits()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            Debug.Log("Ground hit at position: " + hit.point);

            foreach (GameObject unit in selectedUnits)
            {
                NavMeshAgent agent = unit.GetComponent<NavMeshAgent>();
                if (agent != null)
                {
                    agent.SetDestination(hit.point);
                    Debug.Log("Moving unit to: " + hit.point);
                }
                else
                {
                    Debug.Log("NavMeshAgent component missing on the selected unit.");
                }
            }
        }
        else
        {
            Debug.Log("No ground hit.");
        }
    }

    void ClearSelection()
    {
        foreach (GameObject unit in selectedUnits)
        {
            ChangeSprite(unit, false);
        }

        selectedUnits.Clear();
    }

    void OnGUI()
    {
        if (isSelecting && isBoxValid)
        {
            GUI.Box(selectionBox, "");
        }
    }
}