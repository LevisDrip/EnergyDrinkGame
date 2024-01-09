using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacleInteraction : MonoBehaviour
{
    //needed for spike obstacle interaction
    Vector3 startPosition;

    //needed for beartrap interaction
    public PlayerMovement playerMovementScript;
    //public int escapeBearTrapNumber = 1;
    public bool isStuck;

    public float TimeTillRandom;

    void Start()
    {


        //sets the position where the player spawns in as the Vector3 for when it hits a spike obstacle
        startPosition = transform.position;
    }

    void Update()
    {

        //if (isStuck && Input.GetKeyDown(KeyCode.Space))
       // {
        //    escapeBearTrapNumber--;
       // }

        TimeTillRandom -= Time.deltaTime;
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
        //if (collision.gameObject.CompareTag("BeartrapObstacle"))
        //{
        //    transform.position = new Vector2(collision.transform.position.x, -6.045001f);

        //    isStuck = true;
        //    playerMovementScript.Speed = 0;
        //    playerMovementScript.JumpStrenght = 0;

        //    escapeBearTrapNumber += Random.Range(2, 5);
            
        //}

        //if (playerMovementScript.Speed <= 0 && escapeBearTrapNumber <= 0)
        //{
        //    Destroy(collision.gameObject);
        //    Debug.Log("Trap should be destroyed");
        //}
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    isStuck = false;
    //    playerMovementScript.Speed = playerMovementScript.MoveSpeed;
    //    playerMovementScript.JumpStrenght = 300;
    //}
}
