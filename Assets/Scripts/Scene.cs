using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Scene management.
/// </summary>
public class Scene : MonoBehaviour
{
    // Switch the scene from the startscreen to gamescreen
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Switch the scene from the death/winscreen to gamescreen
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Exits the game
    public void Quit()
    {
        Application.Quit();
    }
}
