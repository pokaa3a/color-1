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
    public int r { get; private set; }      // row
    public int c { get; private set; }      // col
    public float u { get; private set; }    // x coord
    public float v { get; private set; }    // y coord
    public float w { get; private set; }    // width
    public float h { get; private set; }    // height

    private GameObject gameObject;

    public Tile(Vector2Int rc, Vector2 wh)
    {
        gameObject = new GameObject($"tile_{r}_{c}");

        this.r = rc.x;
        this.c = rc.y;
        Vector2 uv = Map.Instance.RowCol2XY(rc);
        this.u = uv.x;
        this.v = uv.y;
        this.w = wh.x;
        this.h = wh.y;

        // Position
        gameObject.transform.position = new Vector3(this.u, this.v, 0);

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
        gameObject.transform.localScale = new Vector2(w / sprRend.size.x, h / sprRend.size.y);
    }
}
