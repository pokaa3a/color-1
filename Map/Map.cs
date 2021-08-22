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
    private float screenHeight;
    private float screenWidth;
    private float tileHeight;
    private float tileWidth;
    private List<Tile> tiles;

    private Map()
    {
        tiles = new List<Tile>();

        // This gets the Main Camera from the Scene
        Camera mainCam = Camera.main;
        Assert.IsNotNull(mainCam);

        screenHeight = mainCam.orthographicSize * 2f;
        screenWidth = mainCam.aspect * screenHeight;
        tileHeight = screenHeight / rows;
        tileWidth = screenWidth / cols;
    }

    public void Create()
    {
        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < cols; ++c)
            {
                float u = c * tileWidth + tileWidth / 2f - screenWidth / 2f;
                float v = r * tileHeight + tileHeight / 2f - screenHeight / 2f;
                tiles.Add(new Tile(r, c, u, v, tileWidth, tileHeight));
            }
        }
    }

    public void SetTileColor(Vector2 pos, TileColor color)
    {
        int c = (int)((pos.x + screenWidth / 2f) / tileWidth);
        int r = (int)((pos.y + screenHeight / 2f) / tileHeight);

        GetTile(r, c).SetColor(color);
    }

    public Tile GetTile(int r, int c)
    {
        return tiles[r * cols + c];
    }
}
