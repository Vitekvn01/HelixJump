using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDestroy : OnColliderTrigger
{
    [SerializeField] private float forceDestroy;
    protected override void OnOneTriggerExit(Collider other)
    {
        Segments segments = other.GetComponent<Segments>();

        if (segments.Type == SegmentType.Empty)
        {
            GameObject floor = other.transform.parent.gameObject;
            
            for (int i = 0; i < floor.transform.childCount ; i++)
            {
                Transform segment = floor.transform.GetChild(i);
                segments = segment.GetComponent<Segments>(); 
                segments.SetDestroy(); 

                MeshCollider meshCollider = segment.GetComponent<MeshCollider>();
                meshCollider.isTrigger = false;

                segment.gameObject.AddComponent<Rigidbody>();
                Rigidbody rigidbody = segment.GetComponent<Rigidbody>();
                rigidbody.isKinematic = false;
                rigidbody.mass = 1.0f;
                rigidbody.drag = 0.5f;
                rigidbody.angularDrag = 0;

                segment.Translate(new Vector3(0f, 0f, forceDestroy * Time.deltaTime));
                segment.Rotate(new Vector3( 10 * forceDestroy * Time.deltaTime, 0f, 0f));
            }
        }
    }
}

