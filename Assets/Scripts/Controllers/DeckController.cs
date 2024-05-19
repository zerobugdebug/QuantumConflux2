using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    public DeckModel Deck { get; private set; }

    private void Awake()
    {
        Deck = new DeckModel();
    }

    public void AddCardToDeck(CardModel card)
    {
        Deck.AddCard(card);
    }
}
