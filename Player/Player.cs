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

public class Player : MapObject
{
    private PlayerId _id = PlayerId.Alpha;
    public PlayerId id
    {
        get => _id;
        set
        {
            _id = value;
            gameObject.name = $"player_{value}";
            if (value == PlayerId.Alpha)
            {
                spritePath = "Sprites/players/player_0";
            }
            else if (value == PlayerId.Beta)
            {
                spritePath = "Sprites/players/player_1";
            }
            else if (value == PlayerId.Gamma)
            {
                spritePath = "Sprites/players/player_2";
            }
            else
            {
                Assert.IsTrue(false, "Invalid player Id");
            }
            SetSprite(spritePath);
        }
    }

    public Player() { }

    public Player(Vector2Int rc) : base(rc)
    {
        gameObject.name = "player";

        spriteWH = new Vector2(
            Map.Instance.tileWidth * 0.7f,
            Map.Instance.tileHeight * 0.7f);

        SetPosition(rc);
        SetSprite(spritePath);
    }
}
