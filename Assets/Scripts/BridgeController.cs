using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public static Action OnBridgeCollision;

    //[SerializeField] private Collider _bridgeCollider;
    
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
            var collidedInvCont = other.GetComponentInParent<InventoryController>();
            var collidedPlayer = collidedInvCont.GetComponentInParent<PlayerController>();
            

            if (collidedInvCont._collectedPickList.Count > 1) //// Player has pick more than 1
            {
                GameObject go = collidedInvCont.GetLastPick();
                go.transform.parent = transform;
                go.transform.localPosition = new Vector3(0, 0.5f, 0);

                //_bridgeCollider.enabled = false;
                go.GetComponent<BoxCollider>().enabled = false;

                OnBridgeCollision?.Invoke();


                Destroy(this);
            }
            else
            {
                collidedPlayer.SetPlayerPosition(transform.position - collidedPlayer._movDir);
                collidedPlayer.CorrectPlayerPos();
                collidedPlayer.StopCharacter();
            }

            

            

        }
       
    }
}
