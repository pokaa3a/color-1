using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public enum TileColor
{
    Black,
    Red,
    Green,
    Blue
};

public class Tile
{
    public int r { get; private set; }      // row
    public int c { get; private set; }      // col
    public float u { get; private set; }    // x coord
    public float v { get; private set; }    // y coord
    public float w { get; private set; }    // width
    public float h { get; private set; }    // height

    private GameObject gameObject;
    private GameObject tileBlack;
    private GameObject tileRed;
    private GameObject tileGreen;
    private GameObject tileBlue;

    public Tile(int r, int c, float u, float v, float w, float h)
    {
        gameObject = new GameObject($"tile_{r}_{c}");

        this.r = r;
        this.c = c;
        this.u = u;
        this.v = v;
        this.w = w;
        this.h = h;

        // Position
        gameObject.transform.position = new Vector3(this.u, this.v, 0);

        // Sprite
        SetColor(TileColor.Black);
    }

    public void SetColor(TileColor color)
    {
        Debug.Log($"Set color: {color}");
        SpriteRenderer sprRend = gameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;

        if (color == TileColor.Black)
        {
            sprRend.sprite = Resources.Load<Sprite>("Sprites/tiles/tile_black");
        }
        else if (color == TileColor.Red)
        {
            sprRend.sprite = Resources.Load<Sprite>("Sprites/tiles/tile_red");
        }
        else if (color == TileColor.Green)
        {
            sprRend.sprite = Resources.Load<Sprite>("Sprites/tiles/tile_green");
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
