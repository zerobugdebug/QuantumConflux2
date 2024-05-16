using System.Collections.Generic;
using UnityEngine;

public class OpponentHandView : MonoBehaviour
{
    public List<CardView> opponentHandCards;

    public void UpdateView(List<CardModel> opponentHand)
    {
        if (opponentHand == null)
        {
            Debug.LogError("Opponent hand is null");
            return;
        }

        for (int i = 0; i < opponentHandCards.Count && i < opponentHand.Count; i++)
        {
            opponentHandCards[i].UpdateView(opponentHand[i]);
        }
    }
}