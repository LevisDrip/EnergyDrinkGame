using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool HasDied;
    public float GameOver;

    public GameObject Explanation;
    public GameObject Death;
    public GameObject Win;

    public float ExplainThis;

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
        Win.SetActive(false);
        Death.SetActive(false);

        ExplainThis = 5;

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
        GameOver -= Time.deltaTime;

        if (isStuck && Input.GetKeyDown(KeyCode.Space))
        {
            escapeBearTrapNumber--;
        }

        SceneManager SM = GetComponent<SceneManager>();

        if (GameOver <= 0 && HasDied)
        {
            
            SM.LoadMenu();
        }

        ExplainThis -= Time.deltaTime;

        if(ExplainThis <= 0)
        {
            Explanation.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.F) && !HasSlided)
        {
            Debug.Log("Slidin");

            Sliding = 2;
            
            rigidBody.AddForce(transform.right * (Speed * 50));

            TargetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 80);
           
            
            
            

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
            
            Death.SetActive(true);
            HasDied = true;
            GameOver = 5;
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

        if(collision.gameObject.tag == "EndTrigger")
        {
            Win.SetActive(true);
            GameOver = 5;
            HasDied = true;

            Speed = 0;
            MoveSpeed = 0;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FrontCam")
        {

            if (Sliding <= 1.5f)
            {
                Speed -= 1f;
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
