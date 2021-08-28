using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject
{
    // [Public]
    public int r { get; protected set; }
    public int c { get; protected set; }

    // [Private]
    protected GameObject gameObject;
    protected string spritePath;
    protected float spriteW;
    protected float spriteH;

    public MapObject(Vector2Int rc)
    {
        gameObject = new GameObject();
        this.r = rc.x;
        this.c = rc.y;
    }

    public void SetPosition(Vector2Int rc)
    {
        Vector2 xy = Map.Instance.RowCol2XY(rc);
        gameObject.transform.position = new Vector3(xy.x, xy.y, -1f);
    }

    public void SetSprite(string spritePath)
    {
        SpriteRenderer sprRend = gameObject.GetComponent<SpriteRenderer>();
        if (sprRend == null)
        {
            sprRend = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
        }
        sprRend.sprite = Resources.Load<Sprite>(spritePath);
        // Adjust scale
        gameObject.transform.localScale = new Vector2(
            spriteW / sprRend.size.x,
            spriteH / sprRend.size.y);
    }
}
