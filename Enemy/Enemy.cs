using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int r { get; private set; }      // row
    public int c { get; private set; }      // col
    public float u { get; private set; }    // x coord
    public float v { get; private set; }    // y coord
    public float w { get; private set; }    // width
    public float h { get; private set; }    // height
    public int id;

    public void Initialize(Vector2Int rc, Vector2 wh, int id)
    {
        this.r = rc.x;
        this.c = rc.y;
        Vector2 uv = Map.Instance.RowCol2UV(rc);
        this.u = uv.x;
        this.v = uv.y;
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
        Vector2 uv = Map.Instance.RowCol2UV(rc);
        gameObject.transform.position = new Vector3(uv.x, uv.y, -1f);
    }

    private void SetSprite()
    {
        SpriteRenderer sprRend = gameObject.GetComponent<SpriteRenderer>() as SpriteRenderer;
        sprRend.sprite = Resources.Load<Sprite>("Sprites/enemies/minion");

        // Adjust scale
        gameObject.transform.localScale = new Vector2(w / sprRend.size.x, h / sprRend.size.y);
    }

    public void Act()
    {
        StartCoroutine(actionCoroutine());
    }

    private IEnumerator actionCoroutine()
    {
        yield return new WaitForSeconds(1.5f);

        SetPosition(new Vector2Int(r, c + 1));
        EnemyManager.Instance.OneActionCompleted();
    }
}