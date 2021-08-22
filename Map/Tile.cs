using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Tile
{
    public int r { get; private set; }
    public int c { get; private set; }
    public float u { get; private set; }
    public float v { get; private set; }

    private GameObject tileBlack;
    private GameObject tileRed;
    private GameObject tileGreen;
    private GameObject tileBlue;

    public Tile(int r, int c, float u, float v, float w, float h)
    {
        this.r = r;
        this.c = c;
        this.u = u;
        this.v = v;

        GameObject tileBlackPrefab = Resources.Load<GameObject>("Prefabs/tile_black");
        Assert.IsNotNull(tileBlackPrefab);

        GameObject tileBlack = UnityEngine.Object.Instantiate(
            tileBlackPrefab,
            new Vector3(this.u, this.v, 0),
            Quaternion.identity);
        SpriteRenderer renderer = tileBlack.GetComponent<SpriteRenderer>() as SpriteRenderer;
        tileBlack.transform.localScale = new Vector2(w / renderer.size.x, h / renderer.size.y);
    }
}
