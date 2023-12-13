using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;

    public float JumpStrenght;

    public bool IsGrounded;
    public bool HasSlided;
    //public bool isFullSize;

    public float SlideCoolDown;
    //public float sizeCoolDown;

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        SlideCoolDown = 2;
        //isFullSize = true;
    }

    void Update()
    {
        if (SlideCoolDown > 0)
        {
            SlideCoolDown -= Time.deltaTime;
        }
        else
        {
            SlideCoolDown = 0;
        }

        //if (sizeCoolDown > 0)
        //{
        //    SlideCoolDown -= Time.deltaTime;
        //}
        //else
        //{
        //    sizeCoolDown = 0;
        //}

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

        if (Input.GetKeyDown(KeyCode.LeftShift) && !HasSlided)
        {
            Debug.Log("Slidin");

            
            rigidBody.AddForce(transform.right * (MoveSpeed * 50));

            //transform.localScale *= 0.5f;
            //transform.localPosition = new Vector2(0, -3.495f);

            //sizeCoolDown = 0.75f;
            

            SlideCoolDown = 2;

            

            HasSlided = true;
            //isFullSize = false;
        }

        if (SlideCoolDown <= 0)
        {
            HasSlided = false;
        }

        //if (sizeCoolDown <= 0 && !isFullSize)
        //{
        //    transform.localScale *= 2;
        //    transform.localPosition = new Vector2(0, -2.995001f);

        //    isFullSize = true;
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touching floor");
        IsGrounded = true;
    }



}
