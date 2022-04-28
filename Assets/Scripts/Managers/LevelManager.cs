using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private List<LevelController> _levelList;
    [SerializeField] private LevelController _currentLevel;

    private int _currentLevelNumber;
    private int _pickNumber;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        _currentLevelNumber = PlayerPrefs.GetInt("Level", 0);
        GenerateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        PickManager.OnSetPickText += IncreasePickNumber;
    }

    private void OnDisable()
    {
        PickManager.OnSetPickText -= IncreasePickNumber;

    }




    public void GenerateLevel()
    {
        if (_currentLevel !=null)
        {
            Destroy(_currentLevel.gameObject);
        }

        _currentLevel = Instantiate(_levelList[_currentLevelNumber % (_levelList.Count)]);

        PlayerManager.Instance.GeneratePlayer();

    }



    public void IncreaseCurrentLevel()
    {
        _currentLevelNumber++;
        PlayerPrefs.SetInt("Level", _currentLevelNumber);
    }

    public int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt("Level", 0); ;
    }


    public int GetPickNumber()
    {
        return _pickNumber;
    }

    public void IncreasePickNumber()
    {
        _pickNumber++;

    }

    public void ResetPickNumber()
    {
        _pickNumber = 0;
    }


}
