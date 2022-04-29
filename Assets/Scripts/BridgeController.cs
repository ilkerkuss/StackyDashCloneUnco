using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public static Action OnBridgeCollision;

    
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

            Debug.Log(collidedPlayer.IncomingVector);

            if (collidedInvCont._collectedPickList.Count > 1) //// Player has pick more than 1
            {
                GameObject go = collidedInvCont.GetLastPick();
                go.transform.parent = transform;
                go.transform.localPosition = new Vector3(0, 0.5f, 0);

     
                go.GetComponent<BoxCollider>().enabled = false;
                this.GetComponent<BoxCollider>().enabled = false;

                OnBridgeCollision?.Invoke();

                AudioManager.Instance.PlaySoundAtPoint("BridgeSound", transform.position);

                //Destroy(this);
                collidedPlayer.IncomingVector = collidedPlayer._movDir;
            }
            
            else
            {
                Debug.Log("giriþ");
                
                
                collidedPlayer.SetPlayerPosition(transform.position);
                collidedPlayer.CorrectPlayerPos();
                collidedPlayer.StopCharacter();
            }
            

        }
       
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pick"))
        {
            var collidedInvCont = other.GetComponentInParent<InventoryController>();
            var collidedPlayer = collidedInvCont.GetComponentInParent<PlayerController>();

            if (collidedPlayer._movDir != -collidedPlayer.IncomingVector && collidedInvCont._collectedPickList.Count >= 1)
            {
            
                    Debug.Log("çýkýþ");
                    collidedPlayer.SetPlayerPosition(transform.position);
                    collidedPlayer.CorrectPlayerPos();
                    collidedPlayer.StopCharacter();

                

            }


        }
    }
    
    
}
