using System.Collections.Generic;
using UnityEngine;

public class HandModel
{
    private readonly List<CardController> cardControllers;

    /// <summary>
    /// Adds a card to the hand if the hand contains less than 4 cards.
    /// </summary>
    /// <param name="card">The card to add to the hand.</param>
    public void AddCard(CardController cardController)
    {
        if (cardControllers.Count < 4)
        {
            cardControllers.Add(cardController);
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
        if (cardControllers.Count == 0)
        {
            Debug.LogError("No cards available in the hand to draw.");
            return null;
        }
        int randomIndex = Random.Range(0, cardControllers.Count);
        CardController drawnCard = cardControllers[randomIndex];
        cardControllers.RemoveAt(randomIndex);
        return drawnCard;
    }
    public void RemoveCard(CardController cardController)
    {
        if (cardControllers.Count > 1)
        {
            cardControllers.Remove(cardController);
        }
        else
        {
            Debug.LogError("Hand is empty.");
        }
    }

    internal List<CardController> GetCards()
    {
        return cardControllers;
    }
}
