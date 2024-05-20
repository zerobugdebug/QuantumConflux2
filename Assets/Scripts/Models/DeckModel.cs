using System.Collections.Generic;
using UnityEngine;

public class DeckModel
{
    private readonly List<CardController> cards;

    public DeckModel()
    {
        cards = new List<CardController>();
    }


    // Method to add a card to the deck if it contains less than 8 cards
    public void AddCard(CardController card)
    {
        if (cards.Count < 8)
        {
            cards.Add(card);
        }
        else
        {
            Debug.LogError("Deck cannot contain more than 8 cards.");
        }
    }


    // Method to draw a random card from the deck
    public CardController DrawCard()
    {
        if (cards.Count == 0)
        {
            Debug.LogError("No cards available in the deck to draw.");
            return null;
        }
        int randomIndex = Random.Range(0, cards.Count);
        CardController drawnCard = cards[randomIndex];
        cards.RemoveAt(randomIndex);
        return drawnCard;
    }

    // Method to remove a card from the deck
    public void RemoveCard(CardController card)
    {
        if (cards.Count > 1)
        {
            cards.Remove(card);
        }
        else
        {
            Debug.LogError("Deck is empty.");
        }
    }

}
