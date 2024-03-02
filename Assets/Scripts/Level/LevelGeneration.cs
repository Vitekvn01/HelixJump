using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] private Transform axis;
    [SerializeField] private Floor floorPrefab;

    [Header("settings")]
    [SerializeField] private int defaultFloorAmount;
    [SerializeField] private float floorHeight;
    [SerializeField] private int emptySegmentAmount;
    [SerializeField] private int minTrapSegment;
    [SerializeField] private int maxTrapSegment;

    private float lastFloorY = 0;
    public float LastFloorY => lastFloorY;

    private float floorAmount = 0;
    public float FloorAmount => floorAmount;
    private void Start()
    {
        Generate(1);
    }
    public void Generate(int level)
    {
        DestroyChild(); 

        floorAmount = defaultFloorAmount + level;

        axis.transform.localScale = new Vector3(1, floorAmount * floorHeight + floorHeight, 1);
        for (int i = 0; i < floorAmount; i++)
        {
            Floor floor = Instantiate(floorPrefab, transform);
            floor.transform.Translate(0, i * floorHeight, 0);
            floor.name = "floor" + i;

            if (i == 0)
            {
                floor.SetFinishSegment();
            }
            if (i > 0 && i < floorAmount - 1)
            {
                floor.SetRandomRotate();
                floor.AddEmptySegment(emptySegmentAmount);
                floor.AddRandomTrapSegment(Random.Range(minTrapSegment, maxTrapSegment + 1));
            }
            if (i == floorAmount - 1)
            {
                floor.AddEmptySegment(emptySegmentAmount);
                lastFloorY = floor.transform.position.y;
            }
        }

    }
    private void DestroyChild()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i) == axis) continue;

            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
