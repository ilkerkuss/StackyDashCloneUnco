using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{


    private void OnEnable()
    {
        FinishController.OnCollisionWithFinish += LevelPassed;

    }

    private void OnDisable()
    {
        FinishController.OnCollisionWithFinish -= LevelPassed;

    }




    private void LevelPassed()
    {

        FinishController.OnCollisionWithFinish -= LevelPassed;

        GameManager.Instance.GameState = GameManager.GameStates.IsLevelPass;


        CanvasManager.Instance.LevelPassPanel.LevelPassPanelEndLevelOperations();

        AudioManager.Instance.PlaySound("LevelPassSound");

        LevelManager.Instance.IncreaseCurrentLevel();
        LevelManager.Instance.ResetPickNumber();

    }
}
