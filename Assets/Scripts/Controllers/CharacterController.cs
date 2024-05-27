using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    protected CharacterModel characterModel;
    private HandController hand;
    private DeckController selectedDeck;
    private List<DeckController> decks;
    protected CardController selectedCard;
    private bool ready;
    [SerializeField] protected CharacterHandView characterHandView;
    [SerializeField] private CharacterStatsView characterStatsView;

    // Method to initialize the character's hand
    public virtual void Initialize(CharacterModel characterModel, string name)
    {
        this.characterModel = characterModel;
        hand = new HandController();
        decks = new List<DeckController>();
        selectedDeck = new DeckController();
        SetName(name);
        characterStatsView.Initialize(name);
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
            _ = decks.Remove(deck);
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
        characterHandView.InstantiateHand(hand.GetCards());
    }

    public void SubscribeToCardClicked()
    {

        hand.SubscribeToCardClicked(this);

    }

    public void UnSubscribeToCardClicked()
    {

        hand.UnSubscribeToCardClicked(this);

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
        characterStatsView.UpdateView(GetLifePoints(), GetPillz());
    }

    public int GetLifePoints()
    {
        return characterModel.GetLifePoints();
    }

    public int RemoveLifePoints(int amount)
    {
        return characterModel.RemoveLifePoints(amount);
    }

    public int ApplyDamage(CharacterController attacker)
    {
        return RemoveLifePoints(attacker.GetDamage());
    }

    private int GetDamage()
    {
        return selectedCard.GetDamage();
    }

    public CardController GetCurrentCard()
    {
        return selectedCard;
    }

    public int GetAssignedPillz()
    {
        return selectedCard == null ? 0 : selectedCard.GetAssignedPillz();
    }

    public abstract CardController SelectCard();

    public bool IsCardSelected()
    {
        return selectedCard != null;
    }

    public bool IsReady()
    {
        return ready;
    }

    public bool IsCurrentCardPillzAssigned()
    {
        return selectedCard != null && selectedCard.IsPillzAssigned();
    }

    public abstract void AssignPillz();

    public abstract void ResetChargeAssignment();

    public abstract void ConfirmPillzSelection(int value);

    public CardController SelectRandomUnplayedCard()
    {
        return hand.SelectRandomUnplayedCard();
    }

    public void OnCardClicked(CardController card)
    {
        Debug.Log("PlayerController received Card clicked for card: " + card.GetName());
        selectedCard = card;
    }

    public void SetName(string name)
    {
        characterModel.SetName(name);
    }

    public string GetName()
    {
        return characterModel.GetName();
    }

    public int GetPillz()
    {
        return characterModel.GetPillz();
    }

    public int CalculateAttack()
    {
        return selectedCard.CalculateAttack();
    }

    internal void ResetSelectedCard()
    {
        selectedCard = null;
    }

    internal void SetReady(bool ready)
    {
        this.ready = ready;
    }

    public abstract void MarkCard();
}

