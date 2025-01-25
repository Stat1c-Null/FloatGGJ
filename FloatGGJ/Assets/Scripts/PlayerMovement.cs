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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        
        //Jumping
        if((Input.GetButtonDown("Jump") || Input.GetAxis("Vertical") > 0) && isGrounded && JumpingEnabled) {
            isGrounded = false;
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        }
        
        //Movement
        transform.Translate(movementDirection * speed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Ground") {
            isGrounded = true;
        }
    }
}
