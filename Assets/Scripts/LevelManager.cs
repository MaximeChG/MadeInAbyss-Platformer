using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static private GameObject[] coinCount;

    const string mainMenuName = "Main Menu";

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    private void Update()
    {
        
    }

    public void CoinPickedUp()
    {
        // Add all the instances of "coins" into an array
        coinCount = GameObject.FindGameObjectsWithTag("Coin");
       
        // Check if coins left is equal to 0
        if (coinCount.Length -1  == 0)
        {
            // Load the main menu as the game is over.
            SceneManager.LoadScene(mainMenuName);
        }
    }
}
