using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float MoveSpeed;

    public Sprite BearTrapClosed;

    public float JumpStrenght;

    public bool IsGrounded;
    public bool HasSlided;

    public Camera cam;

    public float SlideCoolDown;
    public float Sliding = 2;

    public float LimitX;

    public int escapeBearTrapNumber = 1;
    public bool isStuck;


    private Rigidbody2D rigidBody;

    Quaternion TargetRotation;
    float RotSpeed = 45;

    void Start()
    {
        Speed = MoveSpeed;

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

        if (isStuck && Input.GetKeyDown(KeyCode.Space))
        {
            escapeBearTrapNumber--;
        }


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

        if (collision.gameObject.tag == "BeartrapObstacle" && !isStuck)
        {
            Debug.Log("stucked");

            

            Speed = 0;
            JumpStrenght = 0;

            //transform.position = new Vector2(collision.transform.position.x, -6.045001f);

            isStuck = true;
            

            escapeBearTrapNumber += Random.Range(2, 5);

        }

        if(collision.gameObject.tag == "SpikeObstacle" || collision.gameObject.tag == "OutOfBounds")
        {
            MoveSpeed = 0;
            Destroy(gameObject);    
        }

        if (collision.gameObject.tag == "Energy")
        {
            Debug.Log("Can Event");

            Destroy(collision.gameObject);
            MoveSpeed += 0.5f;
            Speed = MoveSpeed;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FrontCam")
        {

            if (Sliding <= 0)
            {
                Speed -= 0.1f;
            }

        }
       else  if (collision.gameObject.tag == "BackCam" && !isStuck)
       {
            Debug.Log("BackCam");

            Speed += 0.01f;
       }

        

        if (Speed <= 0 && escapeBearTrapNumber <= 0)
        {
            if(collision.gameObject.tag == "BeartrapObstacle")
            {
                Destroy(collision.gameObject);
                Debug.Log("Trap should be destroyed");
            }

            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FrontCam" || collision.gameObject.tag == "BackCam" && !isStuck)
        {
            Speed = MoveSpeed;
        }


        if(collision.gameObject.tag == "BeartrapObstacle" && isStuck)
        {
            Debug.Log("Unstucked");

            isStuck = false;
            Speed = MoveSpeed;
            JumpStrenght = 550;
        }
        
    }

}
