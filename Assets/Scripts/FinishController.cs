using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    public static Action OnCollisionWithFinish;
    public static Action<GameObject> FinishBoxAction;


    [SerializeField] private GameObject _confettiObject;
    [SerializeField] private GameObject _finishBox;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.transform.name);
        if (collision.transform.CompareTag("Player"))
        {
            FinishBoxAction?.Invoke(_finishBox);

            OnCollisionWithFinish?.Invoke();

            _confettiObject.SetActive(true);
        }
    }
}