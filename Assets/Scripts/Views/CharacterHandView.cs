using System.Collections.Generic;
using UnityEngine;

public class CharacterHandView : MonoBehaviour
{
    // Method to update the hand view with a list of card controllers
    public void UpdateView(List<CardController> cardControllers)
    {
        if (cardControllers == null || cardControllers.Count == 0)
        {
            Debug.LogError("CardControllers list is null or empty");
            return;
        }

        // Update each card view with the corresponding card controller
        foreach (CardController cardController in cardControllers)
        {
            if (cardController == null)
            {
                Debug.LogError("CardController is null");
                continue;
            }

            cardController.UpdateView();
        }
    }

    // TODO: Method to select a card from the hand
    public CardController SelectCard()
    {
        return null; 
    }
}