using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform playerHandTransform;
    public Transform opponentHandTransform;

    public void InstantiateHand(List<CardModel> hand, CharacterHandView handView)
    {
        foreach (CardModel card in hand)
        {
            InstantiateCard(card, handView.transform);
        }

        handView.UpdateView(hand);
    
    }

    private void InstantiateCard(CardModel card, Transform parentTransform)
    {
        GameObject cardObject = Instantiate(cardPrefab, parentTransform);
        CardView cardView = cardObject.GetComponent<CardView>();
        cardView.UpdateView(card);
    }
}
