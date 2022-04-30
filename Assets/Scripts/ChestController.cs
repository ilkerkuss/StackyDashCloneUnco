using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private Animator _chestAnim;


    private void OnEnable()
    {
        FinishController.OnCollisionWithFinish += OpenChest;
    }
    private void OnDisable()
    {
        FinishController.OnCollisionWithFinish -= OpenChest;
    }



    public void OpenChest()
    {
        _chestAnim.SetBool("IsFinish",true);
    }
}
