using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrawColor : Card
{
    public CardDrawColor(Color color) : base()
    {
        // Card sprite
        if (color == Color.Red)
        {
            spritePath = "Sprites/cards/small_card/draw_red";
            bigSpritePath = "Sprites/cards/big_card/draw_red";
        }
        else if (color == Color.Blue)
        {
            spritePath = "Sprites/cards/small_card/draw_blue";
            bigSpritePath = "Sprites/cards/big_card/draw_blue";
        }
        else if (color == Color.Yellow)
        {
            spritePath = "Sprites/cards/small_card/draw_yellow";
            bigSpritePath = "Sprites/cards/big_card/draw_yellow";
        }

        // Action
        action = new ActionDrawColor(color);
    }
}