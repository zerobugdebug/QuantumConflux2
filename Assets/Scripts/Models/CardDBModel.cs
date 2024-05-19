using UnityEngine;
using System.Collections.Generic;

public class CardDBModel
{
    public List<CardModel> AllCards { get; private set; }

    public CardDBModel()
    {
        AllCards = new List<CardModel>();
    }

    public void AddCard(CardModel card)
    {
        if (!AllCards.Exists(c => c.Id == card.Id))
        {
            AllCards.Add(card);
        }
        else
        {
            Debug.LogError("Card with the same ID already exists in the database.");
        }
    }

    public CardModel GetCardById(int id)
    {
        return AllCards.Find(c => c.Id == id);
    }
}
