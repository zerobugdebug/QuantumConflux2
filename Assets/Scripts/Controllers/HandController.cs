using System;
using System.Collections.Generic;
using UnityEngine;

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
        handModel = new HandModel();
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
    public void SubscribeToCardClicked(CharacterController character)
    {
        foreach (CardController card in GetCards())
        {
            if (!card.IsPlayed)
            {
                Debug.Log("Subscribe to " + card.GetName());
                card.CardClicked += character.OnCardClicked;
            }
        }
    }

    public void RemoveCard(CardController card)
    {
        handModel.RemoveCard(card);
    }

    public CardController DrawCard()
    {
        return handModel.DrawCard();
    }

    public CardController SelectRandomUnplayedCard()
    {
        return handModel.SelectRandomUnplayedCard();
    }

    internal void UpdateView()
    {
        throw new NotImplementedException();
    }

    internal List<CardController> GetCards()
    {
        return handModel.GetCards();
    }

    internal void UnSubscribeToCardClicked(CharacterController character)
    {
        foreach (CardController card in GetCards())
        {
            Debug.Log("Unsubscribe from " + card.GetName());
            card.CardClicked -= character.OnCardClicked;
        }
    }
}
