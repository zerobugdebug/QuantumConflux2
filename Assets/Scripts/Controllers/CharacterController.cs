using UnityEngine;
using System.Collections.Generic;

public abstract class CharacterController : MonoBehaviour
{
    protected CharacterModel characterModel;
    private HandController hand;
    private DeckController selectedDeck;
    private List<DeckController> decks;
    protected CardController selectedCard;
    [SerializeField] protected CharacterHandView characterHandView;
    // TODO: [SerializeField] private CharacterStatsView characterStatsView;

    // Method to initialize the character's hand
    public virtual void Initialize(CharacterModel characterModel)
    {
        this.characterModel = characterModel;
        hand = new HandController();
        decks= new List<DeckController>();
        selectedDeck= new DeckController();
    }

    // Method to add a deck to character
    public virtual void AddDeck(DeckController deck)
    {
        if (decks.Count < 16)
        {
            decks.Add(deck);
        }
        else
        {
            Debug.LogError("Character cannot have more than 16 decks.");
        }
    }

    // Method to remove a deck from a character
    public void RemoveDeck(DeckController deck)
    {
        if (decks.Count > 1)
        {
            decks.Remove(deck);
        }
        else
        {
            Debug.LogError("Character doesn't have any decks.");
        }
    }

    // Method to select a deck
    public void SelectDeck(DeckController deck)
    {
        if (deck == null)
        {
            Debug.LogError("Can't select empty deck");
            return;
        }
        selectedDeck = deck;
    }

    // Method to generate a hand from provided deck
    public void GenerateHand()
    {

        if (selectedDeck == null)
        {
            Debug.LogError("No deck selected");
            return;
        }
        hand.InitializeHand(selectedDeck, 4);
    }

    // Method to shuffle the deck
    protected void ShuffleDeck(List<CardController> deck)
    {
        for (int i = 0 ; i < deck.Count ; i++)
        {
            CardController temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public void UpdateView()
    {
        characterHandView.UpdateView(hand.GetCards());
    }

    public CardController GetCurrentCard()
    {
        return selectedCard;
    }

    public abstract CardController SelectCard();

    public abstract int AssignPillz();
}
