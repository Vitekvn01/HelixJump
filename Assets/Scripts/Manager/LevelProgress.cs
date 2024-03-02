using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgress : BallEvents
{
    private int currentLevel = 1;
    public int CurrentLevel => currentLevel;

    protected override void Awake()
    {
        base.Awake();

        Load();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F1) == true)
        {
            Reset();
        }
    }
    protected override void OnBallCollisionSegment(SegmentType type)
    {
       if (type == SegmentType.Finish)
       {
            currentLevel++;
            Save();
       }
    }
    private void Save()
    {
        PlayerPrefs.SetInt("LevelProgress:currentLevel", currentLevel);
    }
    private void Load()
    {
        currentLevel = PlayerPrefs.GetInt("LevelProgress:currentLevel", 1);
    }
    private void Reset()
    {
        PlayerPrefs.DeleteKey("LevelProgress:currentLevel");

        

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
