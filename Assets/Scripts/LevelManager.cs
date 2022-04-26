using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private List<LevelController> _levelList;
    [SerializeField] private LevelController _currentLevel;

    private int _currentLevelNumber;

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

    public void GenerateLevel()
    {
        if (_currentLevel !=null)
        {
            Destroy(_currentLevel.gameObject);
        }

        _currentLevel = Instantiate(_levelList[_currentLevelNumber % (_levelList.Count)]);

        PlayerManager.Instance.GeneratePlayer();

    }
}
