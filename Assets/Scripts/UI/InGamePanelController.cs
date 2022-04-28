using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGamePanelController : CanvasController
{

    [SerializeField] private Button _tapToStartButton;

    [SerializeField] private Text _levelText;
    [SerializeField] private Text _pickText;

    [SerializeField] private Button _retryButton;


    private void Start()
    {
        SetLevelText();
        SetPickText();
    }



    private void OnEnable()
    {

        PickManager.OnSetPickText += SetPickText;
        FinishController.OnCollisionWithFinish += SetPickText;
    }

    private void OnDisable()
    {

        PickManager.OnSetPickText -= SetPickText;
        FinishController.OnCollisionWithFinish -= SetPickText;

    }




    public void SetLevelText() // Set level number
    {
         _levelText.text = "Level " + (LevelManager.Instance.GetCurrentLevel() + 1).ToString();
        //Debug.Log("Level set text");
    }

    public void SetPickText() //Set pick number of player
    {
         _pickText.text = LevelManager.Instance.GetPickNumber().ToString();
        //Debug.Log("pick set text");
    }

    public void ActivateTapToStartButton()
    {
        _tapToStartButton.gameObject.SetActive(true);
    }

    public void DisableTapToStartButton()
    {
        _tapToStartButton.gameObject.SetActive(false);
    }

    public void OnClickTapToStartButton()
    {
        GameManager.Instance.GameState = GameManager.GameStates.IsGamePlaying;

        DisableTapToStartButton();
    }

    public void OnClickRetryButton()
    {
        GameManager.Instance.RestartGame();
    }

}
