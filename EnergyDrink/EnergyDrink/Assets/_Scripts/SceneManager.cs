using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public bool Game;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scenemanagement();
    }

    public void Scenemanagement()
    {
        PlayerMovement PM = GetComponent<PlayerMovement>();

        if (Input.GetKey("LeftShift") && !Game)
        {
           UnityEngine.SceneManagement.SceneManager.LoadScene(1);
            Game = true;
        }

        if (PM.HasDied && PM.GameOver <= 0)
        {
            
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            PM.HasDied = false;
            Game = false;
        }
    }
}
