using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Map
{
    // Singleton
    private static Map _instance;
    public static Map Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Map();
            }
            return _instance;
        }
    }

    // Step size for each box
    public float step { get; private set; }

    private const int cols = 5;
    private const int rows = 10;
    private List<Tile> tiles;

    private Map()
    {
        tiles = new List<Tile>();
    }

    public void Create()
    {
        // This gets the Main Camera from the Scene
        Camera mainCam = Camera.main;
        Assert.IsNotNull(mainCam);

        float screenHeight = mainCam.orthographicSize * 2f;
        float screenWidth = mainCam.aspect * screenHeight;
        float boxHeight = screenHeight / rows;
        float boxWidth = screenWidth / cols;

        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < cols; ++c)
            {
                float u = c * boxWidth + boxWidth / 2f - screenWidth / 2f;
                float v = r * boxHeight + boxHeight / 2f - screenHeight / 2f;
                tiles.Add(new Tile(r, c, u, v, boxWidth, boxHeight));
            }
        }
    }

    public Tile GetTile(int r, int c)
    {
        return tiles[r * cols + c];
    }
}
