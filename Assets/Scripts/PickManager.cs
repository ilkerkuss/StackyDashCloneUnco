using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickManager : MonoBehaviour
{

    public static PickManager Instance;

    [SerializeField] private GameObject _pick;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _playerInventory;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    void Start()
    {
        
    }


    void Update()
    {
        
    }
    private void OnEnable()
    {
        PickController.OnTriggerWithPick += GeneratePick;
    }
    private void OnDisable()
    {
        PickController.OnTriggerWithPick -= GeneratePick;
    }

    public void GeneratePick() // generates pick under playerInventory obj
    {

        GameObject newPick = Instantiate(_pick,(_playerInventory.transform.position-(Vector3.up* _playerInventory.transform.childCount)* 0.1f),Quaternion.identity);
        newPick.transform.SetParent(_playerInventory.transform);

    }

    public void SetPlayer(PlayerController Player)
    {

        _player = Player.gameObject;
        _playerInventory = Player.GetComponentInChildren<InventoryController>().gameObject;
    }
}
