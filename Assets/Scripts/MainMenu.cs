using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void OpenSettings()
    {
        Debug.Log("Settings Opened!");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
