using System.Collections.Generic;
using UnityEngine;

public class PlayerHandView : MonoBehaviour
{
    public List<CardView> playerHandCards;

    public void UpdateView(List<CardModel> playerHand)
    {
        if (playerHand == null)
        {
            Debug.LogError("Player hand is null");
            return;
        }

        for (int i = 0; i < playerHandCards.Count && i < playerHand.Count; i++)
        {
            playerHandCards[i].UpdateView(playerHand[i]);
        }
    }

    // Method to enable card selection
    public CardModel SelectCard()
    {
        // For simplicity, let's assume the player always selects the first card.
        // This should be replaced with actual selection logic.
        if (playerHandCards.Count > 0)
        {
            return playerHandCards[0].Card;
        }

        Debug.LogError("No cards available to select.");
        return null;
    }
}