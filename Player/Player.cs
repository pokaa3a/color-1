using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public enum PlayerId
{
    Alpha,
    Beta,
    Gamma
}

public class Player
{
    public int r { get; private set; }      // row
    public int c { get; private set; }      // col
    public float u { get; private set; }    // x coord
    public float v { get; private set; }    // y coord
    public float w { get; private set; }    // width
    public float h { get; private set; }    // height

    public PlayerId id { get; private set; }

    private GameObject gameObject;

    public Player(Vector2Int rc, Vector2 wh, PlayerId id)
    {
        gameObject = new GameObject($"player_{id}");

        this.r = rc.x;
        this.c = rc.y;
        Vector2 uv = Map.Instance.RowCol2UV(rc);
        this.u = uv.x;
        this.v = uv.y;
        this.w = wh.x;
        this.h = wh.y;
        this.id = id;

        // Position
        gameObject.transform.position = new Vector3(this.u, this.v, -1f);

        // Sprite
        gameObject.AddComponent<SpriteRenderer>();
        SetSprite();
    }

    private void SetSprite()
    {
        SpriteRenderer sprRend = gameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;

        if (id == PlayerId.Alpha)
        {
            sprRend.sprite = Resources.Load<Sprite>("Sprites/players/player_1");
        }
        else if (id == PlayerId.Beta)
        {
            sprRend.sprite = Resources.Load<Sprite>("Sprites/players/player_2");
        }
        else if (id == PlayerId.Gamma)
        {
            sprRend.sprite = Resources.Load<Sprite>("Sprites/players/player_3");
        }
        else
        {
            Assert.IsTrue(false, "Invalid player Id");
        }

        // Adjust scale
        gameObject.transform.localScale = new Vector2(w / sprRend.size.x, h / sprRend.size.y);
    }
}
