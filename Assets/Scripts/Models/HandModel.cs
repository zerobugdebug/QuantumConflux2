using System.Collections.Generic;
using UnityEngine;

public class HandModel
{
    public List<CardModel> Cards { get; private set; }

    public HandModel()
    {
        Cards = new List<CardModel>();
    }

    public void DrawHand(DeckModel deck)
    {
        Cards.Clear();
        List<CardModel> deckCards = new(deck.Cards);
        for (int i = 0 ; i < 4 ; i++)
        {
            if (deckCards.Count == 0)
            {
                Debug.LogError("Deck does not have enough cards to draw a full hand.");
                break;
            }
            int randomIndex = Random.Range(0, deckCards.Count);
            Cards.Add(deckCards[randomIndex]);
            deckCards.RemoveAt(randomIndex);
        }
    }
}
