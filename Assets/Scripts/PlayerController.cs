using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _chrSpeed;

    [SerializeField] private Vector3 _playerPos;

    public Vector3 _movDir;

    [SerializeField] private GameObject _playerInventoryObject;


    void Start()
    {
        _playerPos = transform.position;
    }

    void Update()
    {
        /*
        if (_movDir == Vector3.zero)
        {
            _movDir = MobileInput.Instance.SwipeDirection;
        }
        */
        
    }

    private void FixedUpdate()
    {
        //MoveCharacter(_movDir);
    }


    public void MoveCharacter(Vector3 direction)
    {
        if (!IsCharacterMoving())
        {
            _rb.velocity = direction * _chrSpeed * Time.fixedDeltaTime;
            _movDir = direction;
        }
        

    }

    public void StopCharacter()
    {
        _rb.velocity = Vector3.zero;
    }

    private bool IsCharacterMoving()
    {
        if (_rb.velocity.magnitude >0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    /*
    private void CollectPickable(GameObject Pickable)
    {
        Pickable.transform.parent = _playerInventoryObject.transform;
        Pickable.transform.localPosition = new Vector3(0,(-(Pickable.transform.localScale.y * (_playerInventoryObject.transform.childCount-1))),0);
        Pickable.transform.rotation = Quaternion.identity;

    }
    */



    private void IncreasePlayerHeight()
    {
        Vector3 increasedPos = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        transform.position = increasedPos;
    }

    private void DecreasePlayerHeight(GameObject Pickable)
    {
        Vector3 increasedPos = new Vector3(transform.position.x, transform.position.y - Pickable.transform.localScale.y, transform.position.z);
        transform.position = increasedPos;
    }

    public void CorrectPlayerPos()
    {
        transform.position = new Vector3(_playerPos.x, transform.position.y, _playerPos.z);

    }

    public void SetPlayerPosition(Vector3 newPos)
    {
        _playerPos = newPos;
    }

    public void SetDirectionVector(Vector3 newDirection)
    {
        _movDir = newDirection;
    }



    private void OnEnable()
    {
        MobileInput.Instance.OnMouseSwipeAction += MoveCharacter;
    }
    
    private void OnDisable()
    {
        MobileInput.Instance.OnMouseSwipeAction -= MoveCharacter;

    }
    

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.CompareTag("Pick"))
        {
            IncreasePlayerHeight();
            //IncreasePlayerHeight(other.gameObject);

            //CollectPickable(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log(collision.transform.name);

        if (collision.transform.CompareTag("Obstacle"))
        {

            SetPlayerPosition(collision.transform.position - _movDir);
            CorrectPlayerPos();

            SetDirectionVector(Vector3.zero);

            
        }
    }

}
