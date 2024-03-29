using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public int currentWorld;
    public Animator animator;
    public PlayerMovement playerMovement;

    void Start()
    {
        currentWorld = 1;
        animator.SetInteger("World", currentWorld);
    }

    void Update()
    {
        if(playerMovement.IsGrounded)
        {
            animator.SetBool("IsGrounded", true);
        }
        else
        {
            animator.SetBool("IsGrounded", false);
        }

        if (Input.GetKeyDown(KeyCode.F) && playerMovement.SlideCoolDown <= 0)
        {
            animator.SetTrigger("Slide");
            Invoke("stopSliding", 2f);
        }
    }

    void stopSliding()
    {
        animator.ResetTrigger("Slide");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("World2Start"))
        {
            currentWorld = 2;
            animator.SetInteger("World", currentWorld);

        }

        if (collision.gameObject.CompareTag("World3Start"))
        {
            currentWorld = 3;
            animator.SetInteger("World", currentWorld);
        }

        if (collision.gameObject.CompareTag("World4Start"))
        {
            currentWorld = 4;
            animator.SetInteger("World", currentWorld);
        }

        if (collision.gameObject.CompareTag("World5Start"))
        {
            currentWorld = 5;
            animator.SetInteger("World", currentWorld);
        }
    }
}
