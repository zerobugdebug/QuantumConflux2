using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerModel playerModel;

    void Start()
    {
        InitializePlayer();
    }

    void InitializePlayer()
    {
        playerModel = new PlayerModel();
        // Initialize player deck, strategies, etc.
        ShuffleDeck(playerModel.Deck);

        // Draw initial hand
        for (int i = 0; i < 4; i++)
        {
            playerModel.DrawCard();
        }
    }

    void Update()
    {
        // Handle player logic, turns, etc.
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