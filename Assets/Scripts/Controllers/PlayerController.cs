using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerModel player;
    public PlayerHandView playerHandView;

    void Start()
    {
        InitializePlayer();
    }

    void InitializePlayer()
    {
        player = new PlayerModel();
        // Initialize player deck, strategies, etc.
        ShuffleDeck(player.Deck);

        // Draw initial hand
        for (int i = 0; i < 4; i++)
        {
            player.DrawCard();
        }

        playerHandView.UpdateView(player.Hand);
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


    // Method to handle card selection
    public CardModel SelectCard()
    {
        CardModel selectedCard = playerHandView.SelectCard();
        player.SelectedCard = selectedCard;
        return selectedCard;
    }
}