using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationController : MonoBehaviour
{
    public PlayerController _player;
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
    }

    private void OnDisable()
    {
        FinishController.OnCollisionWithFinish -= FinishMove;
    }


    public IEnumerator InventoryFinishMove()
    {

        for (int i = _playerInventory._collectedPickList.Count - 1; i >= 0; i--)
        {
            _playerInventory._collectedPickList[i].transform.DOJump(_finishBox.transform.position, 1, 1,.25f).OnComplete(()=>_playerInventory._collectedPickList[i].transform.DOScale(Vector3.zero,.1f));
            //_playerInventory.RemoveLastPickFromList();
            _playerInventory._collectedPickList[i].transform.parent = null;
            
            //Destroy(_playerInventory._collectedPickList[i],1);
            yield return new WaitForSeconds(.1f);
        }
        _player.transform.DOJump(_finishBox.transform.position - Vector3.forward, 1f, 1, 1f).OnComplete(() => _player.transform.GetChild(0).DORotate(180 * Vector3.up, 1f));
        StopCoroutine(InventoryFinishMove());
        DOTween.Clear();
    }

    public void PlayerFinishMove()
    {
        /*
        foreach (var pick in _playerInventory._collectedPickList)
        {
            _player.DecreasePlayerHeight();
        */

        _player.transform.DOJump(_finishBox.transform.position - Vector3.forward, 2f, 1, 1f).OnComplete(()=> _player.transform.GetChild(0).DORotate(180 * Vector3.up, 1f)); 
        
        //_player.transform.GetChild(0).DORotate(180*Vector3.up, 5f).OnComplete(()=> _player.transform.DOMove(_finishBox.transform.position - Vector3.forward, 2)); 
        //_player.transform.DOMove(_finishBox.transform.position - Vector3.forward,2).OnComplete(()=>_player.transform.DOLookAt(Camera.main.transform.position,.5f));
    }


    public void FinishMove()
    {
        StartCoroutine(InventoryFinishMove());
        //PlayerFinishMove();
    }
}
