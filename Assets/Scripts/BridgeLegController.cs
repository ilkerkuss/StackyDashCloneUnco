using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeLegController : MonoBehaviour
{
    public static Action<Vector3> OnCollisionWithBridgeLeg;

    private void OnTriggerEnter(Collider other)
    {
       // var pc = other.GetComponentInParent<PlayerController>();


        if (other.transform.CompareTag("Pick"))
        {
            OnCollisionWithBridgeLeg?.Invoke(transform.position);
           // pc.SetPlayerPosition(transform.position); //Set player position center of the leg for cornerization adjustment.
        }
    }
}
