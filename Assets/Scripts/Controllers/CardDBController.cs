using UnityEngine;

public class CardDBController : MonoBehaviour
{
    public CardDBModel CardDB { get; private set; }

    private void Awake()
    {
        CardDB = new CardDBModel();
        // TODO: Load cards into the database
    }

    public void AddCardToDatabase(CardModel card)
    {
        CardDB.AddCard(card);
    }

    public CardModel GetCardById(int id)
    {
        return CardDB.GetCardById(id);
    }
}
