using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacleInteraction : MonoBehaviour
{
    //needed for spike obstacle interaction
    Vector3 startPosition;

    //needed for beartrap interaction
    public PlayerMovement playerMovementScript;
    public int escapeBearTrapNumber;
    public bool isStuck;

    void Start()
    {
        //sets the position where the player spawns in as the Vector3 for when it hits a spike obstacle
        startPosition = transform.position;
    }

    void Update()
    {
        if (escapeBearTrapNumber < 1)
        {
            isStuck = true;
            playerMovementScript.MoveSpeed = 0;
        }
        else
        {
            isStuck = false;
            playerMovementScript.MoveSpeed = 5;
        }

        if (isStuck && Input.GetKeyDown(KeyCode.Space))
        {
            escapeBearTrapNumber--;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("SpikeObstacle"))
        {
            transform.position = startPosition;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BeartrapObstacle"))
        {
            transform.position = collision.transform.position;
            escapeBearTrapNumber += 3;
        }
    }
}