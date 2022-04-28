using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [SerializeField] private PlayerController _prefabPlayer;
    [SerializeField] private PlayerController _currentPlayer;

    public static Action<PlayerController> SetNewPlayerToCamera;


    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }

    }

    public void GeneratePlayer()
    {
        if (_currentPlayer != null)
        {
            Destroy(_currentPlayer.gameObject);
        }
        _currentPlayer = Instantiate(_prefabPlayer);

        PickManager.Instance.SetPlayer(_currentPlayer);

        SetNewPlayerToCamera?.Invoke(_currentPlayer);
    }

    public GameObject GetCurrentPlayer()
    {
        return _currentPlayer.gameObject;
    }
}
