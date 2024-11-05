using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class simpletrigger : MonoBehaviour
{
    public bool destroyOnTrigger;
    public string tagfilter;


    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagfilter))
        {
            onTriggerEnter.Invoke();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagfilter))
        {
            onTriggerExit.Invoke();

            if (destroyOnTrigger)
                Destroy(gameObject);
        }
    }
}
