using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    [SerializeField] private LevelGeneration levelGeneration;
    [SerializeField] private BallController ballController;
    [SerializeField] private LevelProgress levelProgress;
    private void Start()
    {
        levelGeneration.Generate(levelProgress.CurrentLevel);

        ballController.transform.position = new Vector3(ballController.transform.position.x, levelGeneration.LastFloorY + 1.3f, ballController.transform.position.z);
    }

    
}
