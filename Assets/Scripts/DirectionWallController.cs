using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionWallController : MonoBehaviour
{
    public static Action<Vector3> OnDirectionWallCollision; 

    private Dictionary<Directions, Vector3> WallDirectionDictionary = new Dictionary<Directions, Vector3>() { {Directions.Left,Vector3.left },{ Directions.Right, Vector3.right },{ Directions.Up, Vector3.forward },{ Directions.Down, Vector3.back } };

    public enum Directions
    {
        Left,
        Right,
        Up,
        Down
    }

    public Directions WallDirectionChoice;




    public Vector3 GetDirection()
    {
        return WallDirectionDictionary[WallDirectionChoice];
    }





    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log(collision.transform.name);
        if (collision.transform.CompareTag("Player"))
        {
            OnDirectionWallCollision?.Invoke(GetDirection());
            Debug.Log("actiona yollandý");
        }
    }
}
