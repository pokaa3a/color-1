using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Map
{
    public float screenHeight { get; private set; }
    public float screenWidth { get; private set; }
    public float tileHeight { get; private set; }
    public float tileWidth { get; private set; }

    private const int cols = 5;
    private const int rows = 10;
    private List<Tile> tiles;

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
                // float u = c * tileWidth + tileWidth / 2f - screenWidth / 2f;
                // float v = r * tileHeight + tileHeight / 2f - screenHeight / 2f;
                tiles.Add(new Tile(
                    new Vector2Int(r, c),
                    new Vector2(tileWidth, tileHeight)));
            }
        }
    }

    public void SetTileColor(Vector2 uv, TileColor color)
    {
        // int c = (int)((pos.x + screenWidth / 2f) / tileWidth);
        // int r = (int)((pos.y + screenHeight / 2f) / tileHeight);

        Vector2Int rc = UV2RowCol(uv);
        GetTile(rc).SetColor(color);
    }

    public Tile GetTile(Vector2Int rc)
    {
        return tiles[rc.x * cols + rc.y];
    }

    public Vector2Int UV2RowCol(Vector2 uv)
    {
        return new Vector2Int(
            (int)((uv.y + screenHeight / 2f) / tileHeight),
            (int)((uv.x + screenWidth / 2f) / tileWidth));
    }

    public Vector2 RowCol2UV(Vector2Int rc)
    {
        return new Vector2(
            rc.y * tileWidth + tileWidth / 2f - screenWidth / 2f,
            rc.x * tileHeight + tileHeight / 2f - screenHeight / 2f);
    }
}
