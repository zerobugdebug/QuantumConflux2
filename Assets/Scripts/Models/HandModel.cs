using System.Collections.Generic;
using UnityEngine;

public class HandModel
{
    private readonly List<CardController> cards;

    public HandModel()
    {
        cards = new List<CardController>();
    }

    /// <summary>
    /// Adds a card to the hand if the hand contains less than 4 cards.
    /// </summary>
    /// <param name="card">The card to add to the hand.</param>
    public void AddCard(CardController card)
    {
        if (cards.Count < 4)
        {
            cards.Add(card);
        }
        else
        {
            Debug.LogError("Hand cannot contain more than 4 cards.");
        }
    }

    /// <summary>
    /// Draws a random card from the deck and removes it from the hand.
    /// </summary>
    /// <returns>The drawn CardModel if available, otherwise null.</returns>    
    public CardController DrawCard()
    {
        if (cards.Count == 0)
        {
            Debug.LogError("No cards available in the hand to draw.");
            return null;
        }
        int randomIndex = Random.Range(0, cards.Count);
        CardController drawnCard = cards[randomIndex];
        cards.RemoveAt(randomIndex);
        return drawnCard;
    }
    public void RemoveCard(CardController card)
    {
        if (cards.Count > 1)
        {
            cards.Remove(card);
        }
        else
        {
            Debug.LogError("Hand is empty.");
        }
    }

    public List<CardController> GetCards()
    {
        return cards;
    }
}
