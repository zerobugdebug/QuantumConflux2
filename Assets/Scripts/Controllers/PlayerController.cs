using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerModel playerModel;
    public PlayerStatsView playerStatsView;
    public PlayerHandView playerHandView;

    void Start()
    {
        InitializePlayer();
        UpdatePlayerStats();
    }

    public void InitializePlayer()
    {
        playerModel = new PlayerModel
        {
            Health = 12,
            Charges = 12,
            Deck = new List<CardModel>(), // Load or generate the player's deck
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
        if (playerModel.Deck.Count > 0)
        {
            var card = playerModel.Deck[0];
            playerModel.Deck.RemoveAt(0);
            playerModel.Hand.Add(card);
// playerHandView.UpdateHand(playerModel.Hand);
        }
    }

    public void UpdatePlayerStats()
    {
        playerStatsView.UpdatePlayerStats(playerModel.Health, playerModel.Charges);
    }

    // Additional player-specific methods...
}