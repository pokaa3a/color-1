using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CardManager
{
    private const int maxNumCards = 5;
    private int currentCards = 5;

    [SerializeField]
    private List<CardHolder> cardHolders = new List<CardHolder>();

    private BigCard bigCard;

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
        int id = 0;
        for (int iCard = 0; iCard < maxNumCards; ++iCard)
        {
            GameObject obj = GameObject.Find($"card{iCard}");
            CardHolder cardHolder = new CardHolder(obj, id++);
            cardHolders.Add(cardHolder);
        }

        GameObject bigCardObj = GameObject.Find("bigCard");
        bigCard = new BigCard(bigCardObj);
        bigCard.spritePath = "Sprites/cards/big_card_empty";
        bigCard.enabled = false;
    }

    public void RefreshHandCards()
    {

    }

    public void LongPressCard(CardHolder card)
    {
        bigCard.enabled = true;
    }

    public void StopLongPressCard()
    {
        bigCard.enabled = false;
    }
}
