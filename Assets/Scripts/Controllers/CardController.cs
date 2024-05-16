using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform playerHandTransform;
    public Transform opponentHandTransform;

    public void InstantiatePlayerHand(List<CardModel> playerHand)
    {
        foreach (var cardModel in playerHand)
        {
            InstantiateCard(cardModel, playerHandTransform);
        }
    }

    public void InstantiateOpponentHand(List<CardModel> opponentHand)
    {
        foreach (var cardModel in opponentHand)
        {
            InstantiateCard(cardModel, opponentHandTransform);
        }
    }

    private void InstantiateCard(CardModel cardModel, Transform parentTransform)
    {
        var cardObject = Instantiate(cardPrefab, parentTransform);
        var cardView = cardObject.GetComponent<CardView>();
        cardView.UpdateView(cardModel);
    }
}
