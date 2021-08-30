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
            Map.Instance.tileWidth * 0.5f,
            Map.Instance.tileHeight * 0.6f);

        SetPosition(rc);
        SetSprite(this.spritePath);
    }
}
