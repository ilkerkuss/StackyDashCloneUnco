using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickController : MonoBehaviour
{
    public static Action OnTriggerWithPick;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pick"))
        {
            OnTriggerWithPick?.Invoke();


            AudioManager.Instance.PlaySoundAtPoint("PickSound",transform.position);

            Destroy(gameObject);
        }
       
    }


}
