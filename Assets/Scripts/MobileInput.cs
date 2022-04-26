using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MobileInput : MonoBehaviour
{
    public static MobileInput Instance;

    public Action<Vector3> OnMouseSwipeAction;

    private Dictionary<SwipeDirections, Vector3> DirectionDictionary = new Dictionary<SwipeDirections, Vector3>() {{ SwipeDirections.Left, Vector3.left },{SwipeDirections.Right,Vector3.right },{SwipeDirections.Up,Vector3.forward },{ SwipeDirections.Down,Vector3.back}};

    public enum SwipeDirections
    {
        Left,
        Right,
        Up,
        Down
    }

    public Vector3 SwipeDirection;

    //public bool  swipeLeft, swipeRight, swipeUp, swipeDown;
    [SerializeField]private Vector2 swipeDelta, startPos;
    private const float swipeSpace = 100;


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
        GetSwipeDirection(); // get inputs

    }

   



    public void GetSwipeDirection()
    {
        if (Input.GetMouseButtonDown(0))
        {

            startPos = Input.mousePosition;

        }else if (Input.GetMouseButtonUp(0))
        {
            swipeDelta = startPos = Vector2.zero;
        }

        swipeDelta = Vector2.zero;
        if (startPos != Vector2.zero)
        {
            if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startPos;
            }
        }
        

        if (swipeDelta.magnitude > swipeSpace)
        {
            if (Math.Abs(swipeDelta.x) > Math.Abs(swipeDelta.y))
            {
                if (swipeDelta.x < 0)
                {
                    //SwipeDirection = GetDirectionVector(SwipeDirections.Left);
                    OnMouseSwipeAction?.Invoke(GetDirectionVector(SwipeDirections.Left));
                   // Debug.Log("sol");
                }
                else
                {
                    //SwipeDirection = GetDirectionVector(SwipeDirections.Right);
                    OnMouseSwipeAction?.Invoke(GetDirectionVector(SwipeDirections.Right));
                    //Debug.Log("sað");

                }
            }
            else
            {
                if (swipeDelta.y < 0)
                {
                    //SwipeDirection = GetDirectionVector(SwipeDirections.Down);
                    OnMouseSwipeAction?.Invoke(GetDirectionVector(SwipeDirections.Down));
                    //Debug.Log("aþþa");
                }
                else
                {
                    //SwipeDirection = GetDirectionVector(SwipeDirections.Up);
                    OnMouseSwipeAction?.Invoke(GetDirectionVector(SwipeDirections.Up));
                    //Debug.Log("yukarý");
                }
            }

            swipeDelta = startPos = Vector2.zero;
        }
    }

    public Vector3 GetDirectionVector(SwipeDirections swipeDir)
    {
        return DirectionDictionary[swipeDir];
    }

    /*
    public void GetSwipeDirection()
    {
        //Input
        if (Input.GetMouseButtonDown(0))
        {
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTouch = swipeDelta = Vector2.zero;
        }


        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                startTouch = Input.mousePosition;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector2.zero;
            }

        }


        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            // Mobil için
            if (Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            // Bilgisayar için
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;

            }
        }

        //  Deadzone u geçtik mi
        if (swipeDelta.magnitude > deadZone)
        {
            // evet geçtik
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {

                if (x < 0)
                {
                    // sol
                    swipeLeft = true;
                   SwipeDirection = SwipeDirections.SwipeLeft;
                }
                else
                {
                    // sag
                    swipeRight = true;
                    SwipeDirection = SwipeDirections.SwipeRight;
                }
            }
            else
            {

                if (y < 0)
                {

                    swipeDown = true;
                    SwipeDirection = SwipeDirections.SwipeDown;
                }
                else
                {

                    swipeUp = true;
                    SwipeDirection = SwipeDirections.SwipeUp;
                }
            }

            startTouch = swipeDelta = Vector2.zero;
        }

        //return SwipeDirection;
        Debug.Log(SwipeDirection);
    }
    */
}

