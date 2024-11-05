using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public float targetHeight = 10f;
    public float speed = 3f;


    Vector3 startPosition;
    bool reachTarget;

    void Start()
    {
        startPosition = transform.position;
    }

    
    void Update()
    {
        if (reachTarget)
        {
            Vector3 targetposition = new Vector3(startPosition.x, targetHeight, startPosition.z);

            transform.position = Vector3.MoveTowards(transform.position, targetposition, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        }
    }
    public void ToggleReachTarget()
    {
        reachTarget = !reachTarget;
    }
}
