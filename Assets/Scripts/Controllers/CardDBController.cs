using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CardDBController : MonoBehaviour
{
    private CardDBModel cardDBModel;
    [SerializeField]
    private TextAsset cardDataJson; // Drag-and-drop JSON file in the Inspector

    // Method to initialize the card database model
    public void Initialize(CardDBModel cardDBModel)
    {
        this.cardDBModel = cardDBModel;

        // Load card data from the JSON file
        if (cardDataJson != null)
        {
            LoadCardData(cardDataJson.text);
        }
        else
        {
            Debug.LogError("Card data JSON file is not assigned.");
        }
    }

    // Method to load card data from JSON file
    public void LoadCardData(string jsonData)
    {
        CardList cardList = JsonUtility.FromJson<CardList>(jsonData);
        if (cardList != null && cardList.cardModels != null)
        {
            foreach (var cardModel in cardList.cardModels)
            {
                CardController card = gameObject.AddComponent<CardController>();
                card.Initialize(cardModel);
                cardDBModel.AddCard(card);
            }
        }
        else
        {
            Debug.LogError("Failed to parse card data from JSON.");
        }
    }

    // Method to add a card to the database
    public void AddCard(CardController card)
    {
        cardDBModel.AddCard(card);
    }

    // Method to get a card by its ID
    public CardController GetCardById(int id)
    {
        return cardDBModel.GetCardById(id);
    }

    [System.Serializable]
    private class CardList
    {
        public List<CardModel> cardModels;
    }
}
