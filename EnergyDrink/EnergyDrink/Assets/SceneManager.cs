using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public bool InGame;

    public void Update()
    {
       

        if (Input.GetKey(KeyCode.LeftShift) && !InGame)
        {
            LoadGame();
        }
    }

    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        InGame = true;
    }

    public void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        InGame = false;
    }
}
