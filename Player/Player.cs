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

public class Player : MonoBehaviour
{
    public int r { get; private set; }      // row
    public int c { get; private set; }      // col
    public float x { get; private set; }    // x coord
    public float y { get; private set; }    // y coord
    public float w { get; private set; }    // width
    public float h { get; private set; }    // height

    public PlayerId id { get; private set; }

    public void Initialize(Vector2Int rc, Vector2 wh, PlayerId id)
    {
        this.r = rc.x;
        this.c = rc.y;
        Vector2 uv = Map.Instance.RowCol2XY(rc);
        this.x = uv.x;
        this.y = uv.y;
        this.w = wh.x;
        this.h = wh.y;
        this.id = id;

        // Position
        SetPosition(rc);

        // Sprite
        gameObject.AddComponent<SpriteRenderer>();
        SetSprite();
    }

    public void SetPosition(Vector2Int rc)
    {
        Vector2 xy = Map.Instance.RowCol2XY(rc);
        gameObject.transform.position = new Vector3(xy.x, xy.y, -1f);
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
