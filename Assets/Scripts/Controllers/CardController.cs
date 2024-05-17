using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform playerHandTransform;
    public Transform opponentHandTransform;

    public void InstantiateHand(List<CardModel> hand, CharacterHandView handView)
    {
        foreach (var card in hand)
        {
            InstantiateCard(card, handView.transform);
        }

        handView.UpdateView(hand);
    }

    private void InstantiateCard(CardModel card, Transform parentTransform)
    {
        var cardObject = Instantiate(cardPrefab, parentTransform);
        var cardView = cardObject.GetComponent<CardView>();
        cardView.UpdateView(card);
    }
}
