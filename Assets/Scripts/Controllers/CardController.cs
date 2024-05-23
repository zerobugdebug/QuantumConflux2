using System;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private CardModel cardModel;
    private CardView cardView;
    private GameObject cardPrefab;
    private readonly bool isPlayable = true;

    public event Action<CardController> CardClicked;

    public bool IsPlayed { get; set; } = false;

    public void Initialize(CardModel cardModel, GameObject cardPrefab)
    {
        this.cardModel = cardModel;
        this.cardPrefab = cardPrefab;
    }

    // Method to instantiate a card and assign its view
    public void InstantiateCard(Transform parent = null)
    {
        GameObject cardObject = Instantiate(cardPrefab, parent);

        if (cardObject.TryGetComponent(out cardView))
        {
            cardView.UpdateView(cardModel);
            cardView.SetCardController(this);
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
        if (cardView != null && cardModel != null)
        {
            cardView.UpdateView(cardModel);
        }
        else
        {
            Debug.LogError("CardView or CardModel is null");
        }
    }

    // Method called when the card is clicked
    public void OnCardClicked()
    {
        Debug.Log("Card clicked: " + cardModel.Name);
        if (isPlayable)
        {
            CardClicked?.Invoke(this); // Raise event
        }
        else
        {
            Debug.Log("Cannot interact with this card.");
        }
    }

    public bool IsPillzAssigned()
    {
        return cardModel.IsPillzAssigned();
    }

    public int GetAssignedPillz()
    {
        return cardModel.Pillz;
    }
}
