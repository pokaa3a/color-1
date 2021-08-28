using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MapObject
{
    public Tower(Vector2Int rc) : base(rc)
    {
        spritePath = "Sprites/objects/tower";
        spriteW = Map.Instance.tileWidth * 0.5f;
        spriteH = Map.Instance.tileHeight * 0.6f;

        SetPosition(rc);
        SetSprite(this.spritePath);
    }
}
