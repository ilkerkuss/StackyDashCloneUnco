using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _chrSpeed;

    [SerializeField] private Vector3 _playerPos;

    public Vector3 _movDir;

    [SerializeField] private GameObject _playerInventoryObject;
    [SerializeField] private Animator _playerAnim;

    [SerializeField] private ParticleSystem _dustParticle;

    [SerializeField] private GameObject _playerRig;

    public Vector3 IncomingVector;


    #region UnityEvents


    void Start()
    {
        _playerPos = transform.position;
        _chrSpeed = 750f;
    }



    private void OnEnable()
    {
        MobileInput.Instance.OnMouseSwipeAction += MoveCharacter;
        BridgeController.OnBridgeCollision += DecreasePlayerHeight;
        DirectionWallController.OnDirectionWallCollision += MoveCharacter;
        BridgeLegController.OnCollisionWithBridgeLeg += SetPlayerPosition;
        FinishController.OnCollisionWithFinish += StopCharacter;
        PickManager.Instance.OnGeneratePick += ChangeDustPosition;

    }

    private void OnDisable()
    {
        MobileInput.Instance.OnMouseSwipeAction -= MoveCharacter;
        BridgeController.OnBridgeCollision -= DecreasePlayerHeight;
        DirectionWallController.OnDirectionWallCollision -= MoveCharacter;
        BridgeLegController.OnCollisionWithBridgeLeg -= SetPlayerPosition;
        FinishController.OnCollisionWithFinish -= StopCharacter;
        PickManager.Instance.OnGeneratePick -= ChangeDustPosition;

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Pick"))
        {
            IncreasePlayerHeight();

        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.CompareTag("Obstacle"))
        {

            SetPlayerPosition(collision.transform.position - _movDir); // when player collides with obstacle set player position
            CorrectPlayerPos();
            StopCharacter();


        }
        else if (collision.transform.CompareTag("Wall"))
        {
            StopCharacter();
            CorrectPlayerPos();
        }

    }

    #endregion



    #region PlayerMovementFunctions

    public void MoveCharacter(Vector3 direction)
    {
        if (!IsCharacterMoving() && GameManager.Instance.GameState == GameManager.GameStates.IsGamePlaying)
        {
            _movDir = direction;
            _rb.velocity = _movDir * _chrSpeed * Time.fixedDeltaTime;
            RotateCharacter(_movDir);

            AudioManager.Instance.PlaySound("SwipeSound");
            _playerAnim.SetBool("IsMoving", true);
            CreateDust();

        }
    }

    public void StopCharacter()
    {
        _rb.velocity = Vector3.zero;
        _movDir = Vector3.zero;

        _playerAnim.SetBool("IsMoving", false);
        StopDust();
    }

    private bool IsCharacterMoving()
    {
        if (_rb.velocity.magnitude > 0)
        {

            return true;
        }
        else
        {

            return false;
        }
    }

    private void RotateCharacter(Vector3 rotateDir)
    {
        if (rotateDir == Vector3.right)
        {
            _playerRig.transform.DORotate(90 * Vector3.up, .35f);
        }
        else if (rotateDir == Vector3.left)
        {
            _playerRig.transform.DORotate(-90 * Vector3.up, .35f);
        }
        else if (rotateDir == Vector3.forward)
        {

            _playerRig.transform.DORotate(0 * Vector3.up, .35f);
        }
        else
        {
            _playerRig.transform.DORotate(180 * Vector3.up, .35f);
        }

    }
    #endregion



    #region PlayerPositionFunctions

    public void IncreasePlayerHeight()
    {
        Vector3 increasedPos = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        transform.position = increasedPos;
    }

    public void DecreasePlayerHeight()
    {
        Vector3 decreasedPos = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
        transform.position = decreasedPos;
    }

    public void CorrectPlayerPos()
    {
        transform.position = new Vector3(_playerPos.x, transform.position.y, _playerPos.z);
    }

    public void SetPlayerPosition(Vector3 newPos)
    {
        _playerPos = newPos;
    }

    #endregion



    #region Dust Particle Function

    public void CreateDust()
    {
        _dustParticle.Play();
    }

    public void StopDust()
    {
        _dustParticle.Stop();
    }

    public void ChangeDustPosition(GameObject LastPick) // Changes Dust particle position according to last pick position
    {
        _dustParticle.transform.position = LastPick.transform.position;
    }

    #endregion

   

}
