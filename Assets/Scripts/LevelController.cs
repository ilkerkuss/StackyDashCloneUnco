using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    
    void Start()
    {
        
    }



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

       
        CanvasManager.Instance.InGamePanel.HidePanel(); //Hides InGamePanel when collide finish object.
        CanvasManager.Instance.LevelPassPanel.ShowPanel(); //Shows LevelPassPanel when collide finish object.

        CanvasManager.Instance.LevelPassPanel.SetScoreText();
        CanvasManager.Instance.LevelPassPanel.SetCoinText();
        

        LevelManager.Instance.IncreaseCurrentLevel();
        CanvasManager.Instance.InGamePanel.SetLevelText();

        LevelManager.Instance.ResetPickNumber();
        CanvasManager.Instance.InGamePanel.SetPickText();


    }
}
