using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMaxScoreText : MonoBehaviour
{
    [SerializeField] private Text MaxScoreText;
    [SerializeField] private ScoresCollector scoresCollector;

    private void Start()
    {
        MaxScoreText.text = "Рекорд:" + scoresCollector.MaxScores.ToString();
    }
}
