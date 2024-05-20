using UnityEngine;
using System.Collections.Generic;

public class CardDBModel
{
    private readonly List<CardController> cards;

    public CardDBModel()
    {
        cards = new List<CardController>();
    }

    // Method to add a card to the list if it doesn't already exist
    public void AddCard(CardController card)
    {
        cards.Add(card);
/*        if (!cards.Exists(c => c.Id == card.Id))
        {
            cards.Add(card);
        }
        else
        {
            Debug.LogError("Card with the same ID already exists in the database.");
        }
*/    }

    // Method to find and return a card by its ID
    public CardController GetCardById(int id)
    {
        return cards[id];
    }
}
