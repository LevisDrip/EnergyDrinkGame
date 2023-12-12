using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    //takes care of the movement of the player
    public float moveSpeed;
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");

        rigidBody.velocity = new Vector2(moveX * moveSpeed, 0);
    }
}
