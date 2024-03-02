using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamePanel : BallEvents
{
    [SerializeField] private GameObject passedPanel;
    [SerializeField] private GameObject defeatPanel;
    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Trap)
        {
            defeatPanel.SetActive(true);
        }
        if (type == SegmentType.Finish)
        {
            passedPanel.SetActive(true);
        }
    }
    void Start()
    {
        passedPanel.SetActive(false);
        defeatPanel.SetActive(false);
        

    }

}
