using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5.0f;
    public float jump = 5.0f;
    private Vector3 movementDirection;
    public bool isGrounded;
    public bool JumpingEnabled;

    private bool isColliding;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueManager.isActive == true || PhoneTrigger.isActive == true)
        {
            animator.SetBool("isWalking", false); 
            return; 
        }
        movementDirection = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        

        if (movementDirection.x == 0.0f)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            float xScale = transform.localScale.x;
            // Flip view direction
            if (movementDirection.x > 0.0f && xScale < 0 || movementDirection.x < 0.0f && xScale > 0) { transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); }
            animator.SetBool("isWalking", true);
        }

        //Jumping
        if((Input.GetButtonDown("Jump") || Input.GetAxis("Vertical") > 0) && isGrounded && JumpingEnabled) {
            isGrounded = false;
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        }

        //Movement
        //transform.Translate(movementDirection * speed * Time.deltaTime * Math.Abs(transform.localScale.x));
        if (!isColliding)
        {
            Vector3 force = movementDirection * speed * Time.deltaTime * Math.Abs(transform.localScale.x);
            rb.MovePosition(rb.position + force);
        }
    }

    public void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Ground") {
            isGrounded = true;
        }
        if(other.collider.tag == "Boundary")
        {
            isColliding = true;
        }
    }
    
    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Boundary")
        {
            isColliding = false;
        }
    }
}
