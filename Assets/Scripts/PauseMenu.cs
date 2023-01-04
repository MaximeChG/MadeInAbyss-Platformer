using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string mainMenuScene;

    public void ResolutionChange()
    {
        Debug.Log("Resolution Changed");
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
