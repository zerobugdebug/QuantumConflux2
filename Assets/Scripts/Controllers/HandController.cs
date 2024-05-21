using System;
using System.Collections.Generic;

public class HandController
{
    private HandModel handModel;

    /// <summary>
    /// Initializes the hand by drawing a specified number of cards from the deck.
    /// </summary>
    /// <param name="deck">The controller responsible for the deck.</param>
    /// <param name="numberOfCards">The number of cards to draw from the deck.</param>
    public void InitializeHand(DeckController deck, int numberOfCards)
    {
        handModel=new HandModel();
        for (int i = 0 ; i < numberOfCards ; i++)
        {
            CardController drawnCard = deck.DrawCard();
            if (drawnCard != null)
            {
                handModel.AddCard(drawnCard);
            }
        }
    }

    public void AddCard(CardController card)
    {
        handModel.AddCard(card);
    }

    public void RemoveCard(CardController card)
    {
        handModel.RemoveCard(card);
    }

    public CardController DrawCard()
    {
        return handModel.DrawCard();
    }

    internal void UpdateView()
    {
        throw new NotImplementedException();
    }

    internal List<CardController> GetCards()
    {
        return handModel.GetCards();
    }
}
