using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    //this should all be set up cleaner with less inspector stuff later
    [Header("UI elements")]
    public GameObject unitDraft;
    public GameObject battleUI;
    public GameObject loseMenu;
    public GameObject winMenu;

    InputAction winKey;
    InputAction loseKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        unitDraft.SetActive(false);
        battleUI.SetActive(false);
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
        SceneManager.sceneLoaded += OnSceneLoaded;

        winKey = InputSystem.actions.FindAction("Sprint");
        loseKey = InputSystem.actions.FindAction("Lose");
    }

    private void Update()
    {
        if (winKey.WasPerformedThisFrame())
        {
            Win();
        }
        if (loseKey.WasPerformedThisFrame())
        {
            Lose();
        }
    }

    // Update is called once per frame
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //check if NOT main menu scene, then start draft
        if (SceneManager.GetActiveScene().buildIndex != 0)
        { 
            DraftPhase(); 
        }
    }

    public void DraftPhase()
    {
        //Drafting.EndDraft();
        unitDraft.SetActive(true);
        Time.timeScale = 0f;
    }
    public void StartBattle()
    {
        unitDraft.SetActive(false);
        battleUI.SetActive(true);
        Time.timeScale = 1f;
    }

    //Use this to trigger lose when crabtain hp is zero, and place anything else that needs to happen on loss
    public void Lose()
    {
        Debug.Log("lose called");
        battleUI.SetActive(false);
        loseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    //Use this to trigger win when all enemies are defeated and place anything else that needs to happen on win
    public void Win()
    {
        battleUI.SetActive(false);
        winMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    //putting these button click functions here for now to avoid too many separate scripts and clutter in inspector
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(2);
    }
}
