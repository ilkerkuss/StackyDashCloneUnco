using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPassPanelController : CanvasController
{
    [SerializeField] private Button _tapToContinueButton;

    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _coinText;

    private int _coinNumber;


    public void SetScoreText() // Set score number  picknumber*5 = score
    {
        _scoreText.text = "Score :  " + (LevelManager.Instance.GetPickNumber()*5).ToString();
    }

    public void SetCoinText() //Set coin number of player   score/10 = coin
    {

        _coinText.text = (PlayerPrefs.GetInt("Coin",0)).ToString();

    }

    public void SetCoinNumber()
    {
        _coinNumber = PlayerPrefs.GetInt("Coin",0);
        int newCoin = LevelManager.Instance.GetPickNumber() / 2;

        PlayerPrefs.SetInt("Coin",_coinNumber + newCoin);
    }



    public void OnClickTapToContinueButton()
    {
        GameManager.Instance.GameState = GameManager.GameStates.IsGameLoaded;

        CanvasManager.Instance.LevelPassPanel.HidePanel();
        CanvasManager.Instance.InGamePanel.ShowPanel();
        CanvasManager.Instance.InGamePanel.ActivateTapToStartButton();


        CanvasManager.Instance.InGamePanel.SetLevelText();
        CanvasManager.Instance.InGamePanel.SetPickText();

        //next level yarat
        LevelManager.Instance.GenerateLevel();

        AudioManager.Instance.StopSound("LevelPassSound"); //stops the level pass sound

        StopAllCoroutines();

    }

    public void LevelPassPanelEndLevelOperations()
    {
        SetCoinNumber();
        SetCoinText();
        SetScoreText();
    }





}
