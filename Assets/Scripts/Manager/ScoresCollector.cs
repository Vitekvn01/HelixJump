using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresCollector : BallEvents
{
    [SerializeField] private int scores;
    [SerializeField] private LevelProgress levelProgress;
    [SerializeField] private int maxScores;

    private OnColliderTrigger onColliderTrigger;
    private bool bonusScores = false;

    public bool BonysScores => bonusScores;
    public int Scores => scores;
    public int MaxScores => maxScores;

    protected override void Awake()
    {
        base.Awake();
        LoadScores();
    }
    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Empty && bonusScores == false)
        {
            scores += levelProgress.CurrentLevel;
            SaveScores();
        }
        if (type == SegmentType.Empty && bonusScores == true)
        {
            scores += levelProgress.CurrentLevel * 2;
        }
        if (type != SegmentType.Empty)
        {
            bonusScores = false; 
        }
    }
    protected override void OnBallCollisionSegmentExit(SegmentType type)
    {
        if (type == SegmentType.Empty)
        {
            bonusScores = true;
            SaveScores();
        }
    }
    private void Reset()
    {
        PlayerPrefs.DeleteKey("MaxScores");
    }
    private void SaveScores()
    {
        if (maxScores < scores)
        {
            maxScores = scores;
            PlayerPrefs.SetInt("MaxScores", maxScores);
        }
    }
    private void LoadScores()
    {
        maxScores = PlayerPrefs.GetInt("MaxScores", 0);
    }
}
