using System.Collections.Generic;
using UnityEngine;

public class OpponentController : MonoBehaviour
{
    public OpponentModel opponentModel;
    public OpponentStatsView opponentStatsView;
    public OpponentHandView opponentHandView;

    void Start()
    {
        InitializeOpponent();
        UpdateOpponentStats();
    }

    public void InitializeOpponent()
    {
        opponentModel = new OpponentModel
        {
            Health = 12,
            Charges = 12,
            Deck = new List<CardModel>(), // Load or generate the opponent's deck
            Hand = new List<CardModel>()
        };
        DrawInitialHand();
    }

    public void DrawInitialHand()
    {
        for (int i = 0; i < 4; i++)
        {
            DrawCard();
        }
    }

    public void DrawCard()
    {
        if (opponentModel.Deck.Count > 0)
        {
            var card = opponentModel.Deck[0];
            opponentModel.Deck.RemoveAt(0);
            opponentModel.Hand.Add(card);
// opponentHandView.UpdateHand(opponentModel.Hand);
        }
    }

    public void UpdateOpponentStats()
    {
        opponentStatsView.UpdateOpponentStats(opponentModel.Health, opponentModel.Charges);
    }

    // Additional opponent-specific methods...
}
