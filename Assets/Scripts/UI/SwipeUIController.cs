using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SwipeUIController : MonoBehaviour
{
    [SerializeField] private Transform _swipeImg;
   
    private Vector3[] _wayPoints = {new Vector3(250,-950,0),new Vector3(250,-750,0)};
    [SerializeField] private int _cycleLength = 2;


    void Start()
    {
        _swipeImg.DOLocalPath(_wayPoints, _cycleLength).SetLoops(-1,LoopType.Restart);

    }





}
