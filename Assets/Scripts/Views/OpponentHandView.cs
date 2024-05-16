using System.Collections.Generic;
using UnityEngine;

public class OpponentHandView : MonoBehaviour
{
    public Transform handTransform;
    public GameObject cardPrefab;

    public void UpdateHand(List<CardModel> hand)
    {
        // Clear existing cards
        foreach (Transform child in handTransform)
        {
            Destroy(child.gameObject);
        }
        // Instantiate card prefabs for each card in the hand
        foreach (var card in hand)
        {
            GameObject cardGO = Instantiate(cardPrefab, handTransform);
            CardView cardView = cardGO.GetComponent<CardView>();
            cardView.SetCardData(card);
        }
    }
}