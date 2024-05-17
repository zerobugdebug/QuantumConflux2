using System.Collections.Generic;
using UnityEngine;

public class CharacterHandView : MonoBehaviour
{
    public List<CardView> handCards;

    public void UpdateView(List<CardModel> hand)
    {
        if (hand == null)
        {
            Debug.LogError("Hand is null");
            return;
        }

        for (int i = 0; i < handCards.Count && i < hand.Count; i++)
        {
            handCards[i].UpdateView(hand[i]);
        }
    }

    public CardModel SelectCard()
    {
        // For simplicity, let's assume the first card is selected.
        // This should be replaced with actual selection logic.
        if (handCards.Count > 0)
        {
            return handCards[0].Card;
        }

        Debug.LogError("No cards available to select.");
        return null;
    }
}
