using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class AnimationController : MonoBehaviour
{

    public PlayerController _player;
    public Animator PlayerAnim;
    public InventoryController _playerInventory;
    public GameObject _finishBox;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        FinishController.OnCollisionWithFinish += FinishMove;
        FinishController.FinishBoxAction += SetFinishBox;
    }

    private void OnDisable()
    {
        FinishController.OnCollisionWithFinish -= FinishMove;
        FinishController.FinishBoxAction -= SetFinishBox;
    }


    public IEnumerator InventoryFinishMove()
    {
      

        var i = _playerInventory._collectedPickList.Count-1;
        Debug.Log(i);
        
        while (_playerInventory._collectedPickList.Count > 0)
        {
            
            GameObject go = _playerInventory._collectedPickList[i];
            _playerInventory._collectedPickList[i].transform.DOJump(_finishBox.transform.position, 1, 1, .15f).OnComplete(() => _playerInventory._collectedPickList[i].transform.DOScale(Vector3.zero, .1f).OnComplete(()=> _playerInventory.RemoveLastPickFromList()));


            _playerInventory._collectedPickList[i].transform.parent = null;
            _playerInventory._collectedPickList.RemoveAt(i);

            yield return new WaitForSeconds(.1f);
            Destroy(go);
            
            i--;
            Debug.Log(_playerInventory._collectedPickList.Count + " " + i);
        }

        _player.transform.DOMove(_finishBox.transform.position - Vector3.forward, 1f).OnComplete(() => _player.transform.GetChild(0).DORotate(180 * Vector3.up, 1f));

        FinishController.OnCollisionWithFinish -= FinishMove;
        CanvasManager.Instance.InGamePanel.HidePanel();

        yield return new WaitForSeconds(1.5f);
        
        PlayerAnim.SetBool("IsFinish", true);

        
        yield return new WaitForSeconds(3.2f);
        CanvasManager.Instance.LevelPassPanel.ShowPanel();

        StopCoroutine(InventoryFinishMove());
        

    }



    public void SetFinishBox(GameObject FinishBOX)
    {
        _finishBox = FinishBOX;
    }


    public void FinishMove()
    {
        StartCoroutine(InventoryFinishMove());
    }
}
