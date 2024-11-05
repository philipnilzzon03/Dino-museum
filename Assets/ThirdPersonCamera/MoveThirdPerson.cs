using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveThirdPerson : MonoBehaviour
{
    Rigidbody rb;

    public new Transform camera;

    [Header("Movement")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 600f;

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

        Vector3 forwardVector = new Vector3(camera.forward.x, 0f, camera.forward.z).normalized;
        Vector3 rightVector = new Vector3(camera.right.x, 0f, camera.right.z).normalized;

        // Vector describing how much we want to move
        Vector3 moveVector = (forwardVector * vInput) + (rightVector * hInput);

        // Avoid speedy diagonals
        if (moveVector.magnitude > 1) 
            moveVector = moveVector.normalized;

        moveVector *= moveSpeed;

        // Check if player is grounded
        grounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight * 0.5f) + 0.2f, whatIsGround);

        float verticalSpeed = rb.velocity.y;

        // Move and rotate player
        if (grounded)
            rb.velocity = new Vector3(moveVector.x, verticalSpeed, moveVector.z);

        if (moveVector.magnitude > 0.2f) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveVector);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); 
        }
    }
}
