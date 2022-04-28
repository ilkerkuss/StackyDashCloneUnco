using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;

    public InGamePanelController InGamePanel;
    public LevelPassPanelController LevelPassPanel;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }
}
