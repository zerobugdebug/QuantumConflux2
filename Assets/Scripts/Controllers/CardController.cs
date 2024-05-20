using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private CardModel card;
    private CardView cardView;

    [SerializeField]
    private GameObject cardPrefab;


    // Method to instantiate a card and assign its view
    public void InstantiateCard(CardModel card, Transform parent = null)
    {
        this.card = card;

        GameObject cardObject = Instantiate(cardPrefab, parent);

        if (cardObject.TryGetComponent(out cardView))
        {
            cardView.UpdateView(card);
        }
        else
        {
            Debug.LogError("View is not assigned to cardPrefab");
            return;
        }
    }

    // Method to update the card view with the current card model
    public void UpdateView()
    {
        if (cardView != null && card != null)
        {
            cardView.UpdateView(card);
        }
        else
        {
            Debug.LogError("CardView or CardModel is null");
        }
    }
    
}
