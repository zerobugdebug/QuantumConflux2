using System.Collections.Generic;
using UnityEngine;

public class DeckModel
{
    public List<CardModel> Cards { get; private set; }

    public DeckModel()
    {
        Cards = new List<CardModel>();
    }

    public void AddCard(CardModel card)
    {
        if (Cards.Count < 8)
        {
            Cards.Add(card);
        }
        else
        {
            Debug.LogError("Deck cannot contain more than 8 cards.");
        }
    }
}
