using UnityEngine;
using System.Collections.Generic;

public abstract class CharacterController : MonoBehaviour
{
    protected CharacterModel character;
    private HandController handController;
    private DeckController selectedDeckController;
    private readonly List<DeckController> deckControllers;
    protected CardController selectedCard;
    [SerializeField] protected CharacterHandView characterHandView;
    //TODO: [SerializeField] private CharacterStatsView characterStatsView;

    // Method to initialize the character's hand
    public virtual void Initialize(CharacterModel character)
    {
        this.character = character;
        handController= new HandController();
    }

    // Method to add a deck to character
    public virtual void AddDeck(DeckController deckController)
    {
        if (deckControllers.Count <16)
        {
            deckControllers.Add(deckController);
        }
        else
        {
            Debug.LogError("Character cannot have more than 16 decks.");
        }
    }

    // Method to remove a deck from a character
    public void RemoveDeck(DeckController deckController)
    {
        if (deckControllers.Count > 1)
        {
            deckControllers.Remove(deckController);
        }
        else
        {
            Debug.LogError("Character doesn't have any decks.");
        }
    }

        // Method to select a deck
    public void SelectDeck(DeckController deckController)
    {
        if (deckController == null)
        {
            Debug.LogError("Can't select empty deck");
            return;
        }
        selectedDeckController = deckController;
    }

    // Method to generate a hand from provided deck
    public void GenerateHand()
    {

        if (selectedDeckController == null)
        {
            Debug.LogError("No deck selected");
            return;
        }
        handController.InitializeHand(selectedDeckController, 4);
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
        characterHandView.UpdateView(handController.GetCards());
    }

    public CardController GetCurrentCard()
    {
        return selectedCard;
    }

    public abstract CardController SelectCard();

    public abstract int AssignPillz();
}
