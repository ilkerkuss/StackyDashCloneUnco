using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class InventoryController : MonoBehaviour
{
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

    }

    private void OnDisable()
    {
        PickManager.Instance.OnGeneratePick -= AddCollectedPickToList;
        BridgeController.OnBridgeCollision -= RemoveLastPickFromList;

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


    #endregion

}
