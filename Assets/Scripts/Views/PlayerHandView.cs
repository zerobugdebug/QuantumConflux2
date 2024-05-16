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
}