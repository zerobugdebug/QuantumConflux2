using System;
using System.Collections.Generic;

public class HandController
{
    private readonly HandModel hand;

    /// <summary>
    /// Initializes the hand by drawing a specified number of cards from the deck.
    /// </summary>
    /// <param name="deckController">The controller responsible for the deck.</param>
    /// <param name="numberOfCards">The number of cards to draw from the deck.</param>
    public void InitializeHand(DeckController deckController, int numberOfCards)
    {
        for (int i = 0 ; i < numberOfCards ; i++)
        {
            CardController drawnCard = deckController.DrawCard();
            if (drawnCard != null)
            {
                hand.AddCard(drawnCard);
            }
        }
    }

    public void AddCard(CardController card)
    {
        hand.AddCard(card);
    }

    public void RemoveCard(CardController card)
    {
        hand.RemoveCard(card);
    }

    public CardController DrawCard()
    {
        return hand.DrawCard();
    }

    internal void UpdateView()
    {
        throw new NotImplementedException();
    }

    internal List<CardController> GetCards()
    {
        return hand.GetCards();
    }
}
