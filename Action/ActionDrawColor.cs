using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionDrawColor : Action
{
    public TileColor color { get; protected set; }

    public ActionDrawColor(TileColor color)
    {
        this.color = color;

        if (color == TileColor.Red)
        {
            cardSpritePath = "Sprites/cards/card_red";
        }
        else if (color == TileColor.Blue)
        {
            cardSpritePath = "Sprites/cards/card_blue";
        }
        else if (color == TileColor.Yellow)
        {
            cardSpritePath = "Sprites/cards/card_yellow";
        }
    }
}
