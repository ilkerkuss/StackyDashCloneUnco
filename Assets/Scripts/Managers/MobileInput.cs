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


    private Vector2 swipeDelta, startPos;
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
                    OnMouseSwipeAction?.Invoke(GetDirectionVector(SwipeDirections.Left));

                }
                else
                {
                    OnMouseSwipeAction?.Invoke(GetDirectionVector(SwipeDirections.Right));

                }
            }
            else
            {
                if (swipeDelta.y < 0)
                {

                    OnMouseSwipeAction?.Invoke(GetDirectionVector(SwipeDirections.Down));

                }
                else
                {

                    OnMouseSwipeAction?.Invoke(GetDirectionVector(SwipeDirections.Up));

                }
            }

            swipeDelta = startPos = Vector2.zero;
        }
    }

    public Vector3 GetDirectionVector(SwipeDirections swipeDir)
    {
        return DirectionDictionary[swipeDir];
    }
}

