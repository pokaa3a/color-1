using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CardManager
{
    private const int numCards = 3;
    private List<Card> cards = new List<Card>();

    // Singleton
    private static CardManager _instance;
    public static CardManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new CardManager();
            }
            return _instance;
        }
    }

    private CardManager()
    {
        for (int iCard = 0; iCard < numCards; ++iCard)
        {
            Card card = GameObject.Find($"card{iCard}").GetComponent<Card>() as Card;
            cards.Add(card);
        }
    }

    public void SetCards()
    {
        ActionDrawColor drawRed = new ActionDrawColor(TileColor.Red);
        cards[0].RegisterAction(drawRed);

        ActionDrawColor drawBlue = new ActionDrawColor(TileColor.Blue);
        cards[1].RegisterAction(drawBlue);

        ActionDrawColor drawYellow = new ActionDrawColor(TileColor.Yellow);
        cards[2].RegisterAction(drawYellow);
    }
}
