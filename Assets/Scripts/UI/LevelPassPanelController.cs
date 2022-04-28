using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPassPanelController : CanvasController
{
    [SerializeField] private Button _tapToContinueButton;

    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _coinText;


    public void SetScoreText() // Set score number  picknumber*5 = score
    {
        _scoreText.text = "Score :  " + (LevelManager.Instance.GetPickNumber()*5).ToString();
    }

    public void SetCoinText() //Set coin number of player   score/10 = coin
    {
        _coinText.text = (LevelManager.Instance.GetPickNumber()/2).ToString();
    }



    public void OnClickTapToContinueButton()
    {
        GameManager.Instance.GameState = GameManager.GameStates.IsGameLoaded;

        CanvasManager.Instance.LevelPassPanel.HidePanel();
        CanvasManager.Instance.InGamePanel.ShowPanel();
        CanvasManager.Instance.InGamePanel.ActivateTapToStartButton();

        //next level yarat
        LevelManager.Instance.GenerateLevel();

        //AudioManager.Instance.StopSound("LevelPassSound"); //stops the level pass sound


    }





}
