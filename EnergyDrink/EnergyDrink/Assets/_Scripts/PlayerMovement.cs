using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;

    public float JumpStrenght;

    public bool IsGrounded;
    public bool HasSlided;

    public float SlideCoolDown;

    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        SlideCoolDown = 2;
    }

    // Update is called once per frame
    void Update()
    {
        SlideCoolDown -= Time.deltaTime;

        Movement();
    }

    public void Movement()
    {
        transform.position += transform.right * MoveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            IsGrounded = false;
            //transform.position += transform.up * JumpStrenght * Time.deltaTime;
            rigidBody.AddForce(transform.up * JumpStrenght);
        }

        if (Input.GetButtonDown("Slide") && !HasSlided)
        {
            Debug.Log("Slidin'");

            
            rigidBody.AddForce(transform.right * (MoveSpeed * 400));

            

            SlideCoolDown = 2;

            

            HasSlided = true;
        }

        if (SlideCoolDown <= 0)
        {
            HasSlided = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touching floor");
        IsGrounded = true;
    }



}
