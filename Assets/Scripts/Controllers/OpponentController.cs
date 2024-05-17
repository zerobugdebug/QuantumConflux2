using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    public OpponentModel opponent;
    public OpponentHandView opponentHandView;

    void Start()
    {
        InitializeOpponent();
    }

    void InitializeOpponent()
    {
        opponent = new OpponentModel();
        // Initialize opponent deck, strategies, etc.
        ShuffleDeck(opponent.Deck);

        // Draw initial hand
        for (int i = 0; i < 4; i++)
        {
            opponent.DrawCard();
        }
    }

    void Update()
    {
        // Handle opponent logic, turns, etc.
    }

    void ShuffleDeck(List<CardModel> deck)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            CardModel temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }
}