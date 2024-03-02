using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreText : BallEvents
{
    [SerializeField] private ScoresCollector scoresCollector;
    [SerializeField] private Text scoreText;
    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type != SegmentType.Trap)
        {
            scoreText.text = scoresCollector.Scores.ToString();
        }
    }
}
