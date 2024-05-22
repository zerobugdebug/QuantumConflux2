using System.Collections.Generic;
using UnityEngine;

public class CharacterHandView : MonoBehaviour
{
    // Method to update the hand view with a list of card controllers
    public void UpdateView(List<CardController> cards)
    {
        if (cards == null || cards.Count == 0)
        {
            Debug.LogError("CardControllers list is null or empty");
            return;
        }

        // Update each card view with the corresponding card controller
        foreach (CardController card in cards)
        {
            if (card == null)
            {
                Debug.LogError("CardController is null");
                continue;
            }

            card.UpdateView();
        }
    }

    // TODO: Method to select a card from the hand
    public CardController SelectCard()
    {
        return null;
    }

    internal void InstantiateHand(List<CardController> cards)
    {
        if (cards == null || cards.Count == 0)
        {
            Debug.LogError("CardControllers list is null or empty");
            return;
        }

        // Instantiate cards
        foreach (CardController card in cards)
        {
            if (card == null)
            {
                Debug.LogError("CardController is null");
                continue;
            }

            card.InstantiateCard(transform);
        }
    }
}
