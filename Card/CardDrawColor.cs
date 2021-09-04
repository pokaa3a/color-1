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
            spritePath = "Sprites/cards/card_red";
            bigSpritePath = "Sprites/cards/big_card_red";
        }
        else if (color == Color.Blue)
        {
            spritePath = "Sprites/cards/card_blue";
            bigSpritePath = "Sprites/cards/card_blue";
        }
        else if (color == Color.Yellow)
        {
            spritePath = "Sprites/cards/card_yellow";
            bigSpritePath = "Sprites/cards/card_yellow";
        }

        // Action
        action = new ActionDrawColor(color);
    }
}