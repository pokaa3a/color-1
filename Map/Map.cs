using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

// uv: Screen space (1170 x 2532)
// xy: World space (2.31 x 5)
// rc: Row Column

public class Map
{
    // [Public]
    public float screenHeight { get; private set; }
    public float screenWidth { get; private set; }
    public float tileHeight { get; private set; }
    public float tileWidth { get; private set; }
    public List<MapObject> mapObjects { get; private set; }

    // [Private]
    private const int cols = 5;
    private const int rows = 10;
    private const float headMargin = 0.1f;
    private const float botMargin = 0.1f;
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
        mapObjects = new List<MapObject>();

        // This gets the Main Camera from the Scene
        Camera mainCam = Camera.main;
        Assert.IsNotNull(mainCam);

        screenHeight = mainCam.orthographicSize * 2f;
        screenWidth = mainCam.aspect * screenHeight;
        tileHeight = screenHeight * (1f - headMargin - botMargin) / rows;
        tileWidth = screenWidth / cols;
    }

    public void Create()
    {
        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < cols; ++c)
            {
                tiles.Add(new Tile(
                    new Vector2Int(r, c),
                    new Vector2(tileWidth, tileHeight)));
            }
        }
    }

    public void SetTileColor(Vector2 xy, TileColor color)
    {
        Vector2Int rc = XY2RowCol(xy);
        GetTile(rc).SetColor(color);
    }

    public Tile GetTile(Vector2Int rc)
    {
        return tiles[rc.x * cols + rc.y];
    }

    public bool InsideMap(Vector2 xy)
    {
        return xy.x > -screenWidth / 2f &&                          // left
            xy.x < screenWidth / 2f &&                              // right
            xy.y > -screenHeight / 2f + screenHeight * botMargin && // bottom
            xy.y < screenHeight / 2f - screenHeight * headMargin;   // top
    }

    public Vector2Int XY2RowCol(Vector2 xy)
    {
        Assert.IsTrue(InsideMap(xy));
        return new Vector2Int(
            (int)((xy.y + screenHeight / 2f - screenHeight * botMargin) / tileHeight),
            (int)((xy.x + screenWidth / 2f) / tileWidth));
    }

    public Vector2 RowCol2XY(Vector2Int rc)
    {
        return new Vector2(
            rc.y * tileWidth + tileWidth / 2f - screenWidth / 2f,
            rc.x * tileHeight + tileHeight / 2f - screenHeight / 2f + screenHeight * botMargin);
    }

    public void InitializeTowers()
    {
        Tower tower1 = new Tower(new Vector2Int(5, 1));
        mapObjects.Add(tower1);
        Tower tower2 = new Tower(new Vector2Int(5, 3));
        mapObjects.Add(tower2);
    }

    public T AddObject<T>(Vector2Int rc) where T : MapObject, new()
    {
        return GetTile(rc).AddObject<T>(rc) as T;
    }
}
