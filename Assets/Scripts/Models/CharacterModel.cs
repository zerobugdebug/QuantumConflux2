using System.Collections.Generic;

public class CharacterModel
{
    public List<CardModel> Deck { get; set; }
    public List<CardModel> Hand { get; set; }
    public int LifePoints { get; set; }
    public int Pillz { get; set; }
    public CardModel SelectedCard { get; set; }

    public CharacterModel()
    {
        Deck = new List<CardModel>();
        Hand = new List<CardModel>();
        LifePoints = 12;  // Default life points
        Pillz = 12;  // Default Pillz
    }

    public void DrawCard()
    {
        if (Deck.Count > 0)
        {
            Hand.Add(Deck[0]);
            Deck.RemoveAt(0);
        }
    }
}