using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDrawColor : Action
{
    public Color color { get; protected set; }

    public ActionDrawColor(Color color)
    {
        this.color = color;

        if (color == Color.Red)
        {
            cardSpritePath = "Sprites/cards/card_red";
        }
        else if (color == Color.Blue)
        {
            cardSpritePath = "Sprites/cards/card_blue";
        }
        else if (color == Color.Yellow)
        {
            cardSpritePath = "Sprites/cards/card_yellow";
        }
    }

    public override void Act(Vector2 xy)
    {
        if (Map.Instance.InsideMap(xy))
        {
            Map.Instance.SetTileColor(xy, color);
        }
    }
}
