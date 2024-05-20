using UnityEngine;

public class CardDBController : MonoBehaviour
{
    private CardDBModel cardDB;

    // Method to initialize the card database model
    public void Initialize(CardDBModel cardDB)
    {
        this.cardDB = cardDB;
    }

    // Method to add a card to the database
    public void AddCard(CardController card)
    {
        cardDB.AddCard(card);
    }

    // Method to get a card by its ID
    public CardController GetCardById(int id)
    {
        return cardDB.GetCardById(id);
    }
}
