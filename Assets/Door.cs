using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool closed = true;
    public bool mirror = false;
    public float openDegrees = 90f;
    public float openSpeed = 60f;

    float closedDegrees;

    Vector3 closedEulerAngles;
    Vector3 openedEulerAngels;
    
    void Start()
    {
        closedDegrees = transform.localEulerAngles.y;

        closedEulerAngles = new Vector3(0f, closedDegrees, 0f);
        
        if (mirror)
            openedEulerAngels = new Vector3(0f, closedDegrees - openDegrees, 0f);
        else
            openedEulerAngels = new Vector3(0f, closedDegrees + openDegrees, 0f);
    }

   
    void Update()
    {
        if (closed)
            transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, closedEulerAngles, openSpeed * Time.deltaTime);
        else
            transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, openedEulerAngels, openSpeed * Time.deltaTime);
    }

    public void ToggleOpen()
    {
        closed = !closed; 
    }
}
