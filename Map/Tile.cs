using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public enum TileColor
{
    Black,
    Red,
    Yellow,
    Blue
};

public class Tile
{
    public TileColor color { get; private set; } = TileColor.Black;

    public Vector2Int rc { get; private set; }  // row-col
    public Vector2 srpiteWh;

    private GameObject gameObject;
    private List<MapObject> objects;

    public Tile(Vector2Int rc, Vector2 wh)
    {
        gameObject = new GameObject($"tile_{rc.x}_{rc.y}");
        objects = new List<MapObject>();

        this.rc = rc;
        this.srpiteWh = Map.Instance.tileWH;

        // Position
        Vector2 xy = Map.Instance.RCtoXY(rc);
        gameObject.transform.position = new Vector3(xy.x, xy.y, 0);

        // Sprite
        gameObject.AddComponent<SpriteRenderer>();
        SetColor(TileColor.Black);
    }

    public void SetColor(TileColor color)
    {
        this.color = color;
        SpriteRenderer sprRend = gameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
        if (color == TileColor.Black)
        {
            sprRend.sprite = Resources.Load<Sprite>("Sprites/tiles/tile_black");
        }
        else if (color == TileColor.Red)
        {
            sprRend.sprite = Resources.Load<Sprite>("Sprites/tiles/tile_red");
        }
        else if (color == TileColor.Yellow)
        {
            sprRend.sprite = Resources.Load<Sprite>("Sprites/tiles/tile_yellow");
        }
        else if (color == TileColor.Blue)
        {
            sprRend.sprite = Resources.Load<Sprite>("Sprites/tiles/tile_blue");
        }
        else
        {
            Assert.IsTrue(false, "Invalid tile color");
        }

        // Adjust scale
        gameObject.transform.localScale = new Vector2(
            srpiteWh.x / sprRend.size.x,
            srpiteWh.y / sprRend.size.y);
    }

    public T AddObject<T>(Vector2Int rc) where T : MapObject, new()
    {
        T newObject = System.Activator.CreateInstance(typeof(T), rc) as T;
        objects.Add((MapObject)newObject);
        return newObject;
    }
}
