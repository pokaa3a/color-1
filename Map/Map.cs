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
    public Vector2 screenWH { get; private set; }
    // public float screenHeight { get; private set; }
    // public float screenWidth { get; private set; }
    public Vector2 tileWH { get; private set; }
    // public float tileHeight { get; private set; }
    // public float tileWidth { get; private set; }
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

        float screenHeight = mainCam.orthographicSize * 2f;
        float screenWidth = mainCam.aspect * screenHeight;
        this.screenWH = new Vector2(screenWidth, screenHeight);

        float tileHeight = screenHeight * (1f - headMargin - botMargin) / rows;
        float tileWidth = screenWidth / cols;
        this.tileWH = new Vector2(tileWidth, tileHeight);
    }

    public void Create()
    {
        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < cols; ++c)
            {
                tiles.Add(new Tile(
                    new Vector2Int(r, c),
                    new Vector2(tileWH.x, tileWH.y)));
            }
        }
    }

    public void SetTileColor(Vector2 xy, TileColor color)
    {
        Vector2Int rc = XYtoRC(xy);
        GetTile(rc).SetColor(color);
    }

    public Tile GetTile(Vector2Int rc)
    {
        return tiles[rc.x * cols + rc.y];
    }

    public bool InsideMap(Vector2 xy)
    {
        return xy.x > -screenWH.x / 2f &&                          // left
            xy.x < screenWH.x / 2f &&                              // right
            xy.y > -screenWH.y / 2f + screenWH.y * botMargin && // bottom
            xy.y < screenWH.y / 2f - screenWH.y * headMargin;   // top
    }

    public Vector2Int XYtoRC(Vector2 xy)
    {
        Assert.IsTrue(InsideMap(xy));
        return new Vector2Int(
            (int)((xy.y + screenWH.y / 2f - screenWH.y * botMargin) / tileWH.y),
            (int)((xy.x + screenWH.x / 2f) / tileWH.x));
    }

    public Vector2 RCtoXY(Vector2Int rc)
    {
        return new Vector2(
            rc.y * tileWH.x + tileWH.x / 2f - screenWH.x / 2f,
            rc.x * tileWH.y + tileWH.y / 2f - screenWH.y / 2f + screenWH.y * botMargin);
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
