using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlotGeneration : OnColliderTrigger
{
   
    [SerializeField] private GameObject blotPrefab;
    [SerializeField] private float heightBlot;
    protected override void OnOneTriggerEnter(Collider other)
    {
        Segments segments = other.GetComponent<Segments>();

        if (segments != null)
        {
            
            if (segments.Type == SegmentType.Trap || segments.Type == SegmentType.Finish || segments.Type == SegmentType.Default)
            {
                GameObject blot = Instantiate(blotPrefab, new Vector3(transform.position.x, other.transform.position.y + heightBlot, transform.position.z), Quaternion.identity);
                blot.transform.parent = other.transform; 
            }
            
        }
    }

}
