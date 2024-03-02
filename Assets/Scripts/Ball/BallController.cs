using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(BallMovement))]
public class BallController : OnColliderTrigger
{
    private BallMovement movement;

    [HideInInspector] public UnityEvent<SegmentType> CollisionSegment;
    [HideInInspector] public UnityEvent<SegmentType> CollisionSegmentExit;
    private void Start()
    {
        movement = GetComponent<BallMovement>();
    }

    protected override void OnOneTriggerEnter(Collider other)
    {
        Segments segments = other.GetComponent<Segments>();

        if (segments != null)
        {
            if (segments.Type == SegmentType.Empty)
            {
                movement.Fall(other.transform.position.y);
            }
            if (segments.Type == SegmentType.Default)
            {
                movement.Jump();
            }
            if (segments.Type == SegmentType.Trap || segments.Type == SegmentType.Finish)
            {
                movement.Stop();
            }
            CollisionSegment.Invoke(segments.Type);
        }
    }

    protected override void OnOneTriggerExit(Collider other)
    {
        Segments segments = other.GetComponent<Segments>();

        if (segments != null)
        {
            CollisionSegmentExit.Invoke(segments.Type);
            
        }
    }

}
