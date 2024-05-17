using UnityEngine;

public class OpponentController : CharacterController
{
    public OpponentHandView opponentHandView;

    void Start()
    {
        InitializeCharacter();
    }

    public override CardModel SelectCard()
    {
        // Placeholder for AI logic for selecting a card
        CardModel selectedCard = opponentHandView.SelectCard();
        character.SelectedCard = selectedCard;
        return selectedCard;
    }

    public override int AssignPillz()
    {
        int assignedPillz = 3; // Placeholder for AI logic for assigning Pillz
        character.SelectedCard.Pillz = assignedPillz;
        return assignedPillz;
    }
}
