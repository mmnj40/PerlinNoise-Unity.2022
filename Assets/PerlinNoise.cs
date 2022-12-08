using System;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class PerlinNoise : MonoBehaviour
{
    public int _widths = 256;
    public int _height = 256;

    public float scale = 20;

    public float xOffset = 20;
    public float yOffset = 20;

    private void Start()
    {
        xOffset = Random.Range(0f, 9999f);
        yOffset = Random.Range(0f, 9999f);

    }

    private void Update()
    {
        xOffset = Random.Range(0f, 9999f);
        yOffset = Random.Range(0f, 9999f);
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = GenerateTexture();
    }

    private Texture2D GenerateTexture()
    {
        Texture2D texture2D = new Texture2D(_widths, _height);

        for (int x = 0; x < _widths; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                Color color = CalculateColor(x, y);
                texture2D.SetPixel(x,y,color);
            }
        }
        texture2D.Apply();
        return texture2D;
    }

    private Color CalculateColor(int x, int y)
    {
        float xCoord = (float) x / _widths * scale + xOffset;
        float yCoord = (float) y / _height * scale + yOffset;
        
        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
