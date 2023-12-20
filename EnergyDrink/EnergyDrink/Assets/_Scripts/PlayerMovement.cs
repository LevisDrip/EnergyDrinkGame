using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float MoveSpeed;


    public float JumpStrenght;

    public bool IsGrounded;
    public bool HasSlided;

    public Camera cam;

    public float SlideCoolDown;
    public float Sliding = 2;

    public float LimitX;
    

    private Rigidbody2D rigidBody;

    Quaternion TargetRotation;
    float RotSpeed = 45;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        SlideCoolDown = 2;
        
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

        Sliding -= Time.deltaTime;


        Movement();
    }

    public void Movement()
    {
        transform.position += transform.right * Speed * Time.deltaTime;

        cam.transform.position += transform.right * MoveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            IsGrounded = false;
            
            rigidBody.AddForce(transform.up * JumpStrenght);
            
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && !HasSlided)
        {
            Debug.Log("Slidin");

            Sliding = 2;
            
            rigidBody.AddForce(transform.right * (Speed * 50));

            TargetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 80);
           
            
            
            

            SlideCoolDown = 3;

            

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

        if(collision.gameObject.tag == "BackCam")
        {
            Speed += 0.5f;
        }

        
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FrontCam")
        {

            if (Sliding <= 0)
            {
                Speed -= 1;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FrontCam" || collision.gameObject.tag == "BackCam")
        {
            Speed = MoveSpeed;
        }
    }

}
