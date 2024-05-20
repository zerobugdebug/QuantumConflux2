using System.Collections.Generic;
using UnityEngine;

public class DeckController
{
    private DeckModel deck;

    // Method to initialize the deck model
    public void Initialize(DeckModel deck)
    {
        this.deck = deck;
    }


    public void AddCard(CardController card)
    {
        deck.AddCard(card);
    }

    public void RemoveCard(CardController card)
    {
        deck.RemoveCard(card);
    }

    public CardController DrawCard()
    {
        return deck.DrawCard();
    }

}
