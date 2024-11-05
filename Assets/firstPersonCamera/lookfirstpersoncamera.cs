using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]

public class lookfirstpersoncamera : MonoBehaviour
{
    public float sensX = 500f;
    public float sensY = 500f;

    public new Transform camera;
    public float eyeHeight = 1f;

   // Private variables
    float xRotation;
    float yRotation;

    void Start()
    {
        Cursor.visible = false; // Locks Cursor
        Cursor.lockState = CursorLockMode.Locked;

        Vector3 cameraTargetPositipon = transform.position + (Vector3.up * eyeHeight);
        camera.position = cameraTargetPositipon;   
    }

    
    void Update()
    {
        // Create usable mouse movement inputs
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        
        // Prevents camera from turning upside down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        // Set rotation of camera and character
        transform.eulerAngles = new Vector3(0f, yRotation, 0f);
        camera.eulerAngles = new Vector3(xRotation, yRotation, 0f);
        
        // Move camera
        Vector3 cameraTargetPositipon = transform.position + (Vector3.up * eyeHeight);
        camera.position = Vector3.Lerp(camera.position, cameraTargetPositipon, 0.5f);
    }

    public void LockCursor()
    {
        Cursor.visible = false; // Locks Cursor
        Cursor.lockState = CursorLockMode.Locked;
    }
}
