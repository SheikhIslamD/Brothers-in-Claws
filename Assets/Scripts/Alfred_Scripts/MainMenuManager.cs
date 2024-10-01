using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SheikhPrototyping");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayDemo()
    {
        SceneManager.LoadScene("NicolasWorkScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
