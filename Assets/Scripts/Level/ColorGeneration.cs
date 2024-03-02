using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ColorGeneration : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    [SerializeField] private Color[] colors;
    [SerializeField] private Camera cameraBackground;
    private void Start()
    {
        cameraBackground.backgroundColor = colors[Random.Range(0, colors.Length)];

        for (int i = 0; i < materials.Length; i++)
        {
            int j = Random.Range(0, colors.Length);
            materials[i].color = colors[j];

        }
    }
}
