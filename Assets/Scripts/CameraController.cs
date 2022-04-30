using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private PlayerController _player;
    private Vector3 _offset;

    [SerializeField] private Vector3 _inGameOffsetVector = new Vector3(0, 10, -12.5f);

    [SerializeField] private float _lerpValue;


    private void LateUpdate()
    {

        if (_player != null)
        {
            Vector3 newPos = Vector3.Lerp(transform.position, _inGameOffsetVector + _player.transform.position, _lerpValue);
            transform.position = newPos;

        }

    }


    private void OnEnable()
    {

       PlayerManager.SetNewPlayerToCamera += SetCameraTarget;
    }

    private void OnDisable()
    {

        PlayerManager.SetNewPlayerToCamera -= SetCameraTarget;

    }





    private void SetCameraTarget(PlayerController Player)
    {
        _player = Player;
        SetInGameCameraStats();

    }

    private void SetInGameCameraStats()
    {

        _offset = transform.position - _player.transform.position;
        _lerpValue = 3f;

    }
}
