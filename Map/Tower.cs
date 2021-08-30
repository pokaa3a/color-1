using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MapObject
{
    public Tower(Vector2Int rc) : base(rc)
    {
        gameObject.name = "Tower";

        spritePath = "Sprites/objects/tower";
        spriteWH = new Vector2(
            Map.Instance.tileWH.x * 0.5f,
            Map.Instance.tileWH.y * 0.6f);

        SetPosition(rc);
        SetSprite(this.spritePath);
    }
}
