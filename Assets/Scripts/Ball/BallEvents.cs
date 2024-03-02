using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEvents : MonoBehaviour
{
    [SerializeField] protected BallController ballController;
    protected virtual void Awake()
    {
         ballController.CollisionSegment.AddListener(OnBallCollisionSegment);
         ballController.CollisionSegmentExit.AddListener(OnBallCollisionSegmentExit);
    
    }
    protected virtual void OnDestroy()
    {
        ballController.CollisionSegment.RemoveListener(OnBallCollisionSegment);
    }

    protected virtual void OnBallCollisionSegment(SegmentType type) { }
    protected virtual void OnBallCollisionSegmentExit(SegmentType type) { }



}
