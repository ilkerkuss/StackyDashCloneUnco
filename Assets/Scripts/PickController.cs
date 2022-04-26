using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickController : MonoBehaviour
{
    public static Action OnTriggerWithPick;
    //public static Action OnTriggerWithObstacle;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pick"))
        {
            OnTriggerWithPick?.Invoke();

            //PickManager.Instance.GeneratePick();
            Destroy(gameObject);
        }
       
    }


}
