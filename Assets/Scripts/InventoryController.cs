using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class InventoryController : MonoBehaviour
{
    public static Action OnPickAnimation;


    public List<GameObject> _collectedPickList;
    public GameObject _lastPick;

    [SerializeField] private GameObject _mainPick;



    void Start()
    {
        _lastPick = _mainPick;
    }



    private void OnEnable()
    {
        PickManager.Instance.OnGeneratePick += AddCollectedPickToList;
        BridgeController.OnBridgeCollision += RemoveLastPickFromList;
        //FinishController.OnCollisionWithFinish += InventoryFinishMove;
        //FinishController.FinishBoxAction += FinishMove;
    }

    private void OnDisable()
    {
        PickManager.Instance.OnGeneratePick -= AddCollectedPickToList;
        BridgeController.OnBridgeCollision -= RemoveLastPickFromList;
        //FinishController.OnCollisionWithFinish -= InventoryFinishMove;
        //FinishController.FinishBoxAction += FinishMove;
    }







    #region InventoryListFunctions


    public void AddCollectedPickToList(GameObject CollectedPick)
    {

        _collectedPickList.Add(CollectedPick);

        _lastPick = CollectedPick;
    }

    public void RemoveLastPickFromList() // Removes Last instantiated obj under the stack from the CollectedPickList and updates the last pick info
    {
        _collectedPickList.RemoveAt(_collectedPickList.Count - 1);

        //_collectedPickList.RemoveAll(item => item == null); //removes null elements from list after removal operation


        if (_collectedPickList.Count==0)
        {
            _lastPick = _mainPick;
        }
        else
        {
            _lastPick = _collectedPickList[_collectedPickList.Count - 1];
        }
        

    }

    public GameObject GetLastPick()
    {
        return _lastPick;
    }


    public IEnumerator InventoryFinishMove(GameObject finishDest)
    {
        //yield return new WaitForSeconds(.1f);

        for (int i = _collectedPickList.Count - 1; i > 0; i--)
        {
            _collectedPickList[i].transform.DOJump(finishDest.transform.position,1,1,3.1f);
            //Destroy(_collectedPickList[i]);
            //RemoveLastPickFromList();
            OnPickAnimation?.Invoke();

            yield return new WaitForSeconds(.1f);
        }

        
    }

    public void FinishMove(GameObject finishBox)
    {
        StartCoroutine(InventoryFinishMove(finishBox));
    }
    #endregion

}
