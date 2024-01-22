using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float GameOver;
    public GameObject Model;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager SM = FindObjectOfType<SceneManager>();

        SM.InGame = true;

        GameOver = 5;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement PM = GetComponent<PlayerMovement>();



        if (Model == null)
        {
            GameOver -= 1 * Time.deltaTime;

            
        }

        LoadThings();
    }

    public void LoadThings()
    {
        if (GameOver <= 0)
        {
            SceneManager SM = FindObjectOfType<SceneManager>();

            SM.InGame = false;
            SM.LoadMenu();


        }
    }
}
