using System.Collections.Generic;
using UnityEngine;

public class DeckController
{
    private DeckModel deckModel;
    public DeckController()
    {
        this.deckModel = new DeckModel();
    }

    // Method to initialize the deck model
    public void Initialize(DeckModel deckModel)
    {
        this.deckModel = deckModel;
    }


    public void AddCard(CardController card)
    {
        deckModel.AddCard(card);
    }

    public void RemoveCard(CardController card)
    {
        deckModel.RemoveCard(card);
    }

    public CardController DrawCard()
    {
        return deckModel.DrawCard();
    }

}
