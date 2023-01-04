using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string newGameScene;
    public string pauseGameScene;
    public void StartGame()
    {
        SceneManager.LoadScene(newGameScene);
    }

    public void GameOptions()
    {
        SceneManager.LoadScene(pauseGameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
