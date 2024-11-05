using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class moveFirstPersonCamera : MonoBehaviour
{
    Rigidbody rb;

    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Ground Check")]
    public float playerHeight = 2f;
    public LayerMask whatIsGround;
    
    bool grounded;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    
    void Update()
    {
        // Get keyboard input

        float hInput = Input.GetAxisRaw("Horizontal");

        float vInput = Input.GetAxisRaw("Vertical");

        // Create vector describing how much we want to move
        Vector3 moveVector = (transform.forward * vInput) + (transform.right * hInput);

        // Avoid speedy diagonals
        if (moveVector.magnitude > 1f)
            moveVector = moveVector.normalized;

        moveVector *= moveSpeed;

        // Check if player is on ground
        grounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight * 0.5f) + 0.2f, whatIsGround);
        Debug.DrawRay(transform.position, Vector3.down * ((playerHeight * 0.5f) + 0.2f));

        // Move character
        float verticalSpeed = rb.velocity.y;

        if (grounded)
            rb.velocity = new Vector3(moveVector.x, verticalSpeed, moveVector.z);
    }
}
