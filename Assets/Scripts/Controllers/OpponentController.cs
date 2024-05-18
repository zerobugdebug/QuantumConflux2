using UnityEngine;

public class OpponentController : CharacterController
{
    public OpponentHandView opponentHandView;
    public OpponentModel opponent;

    void Start()
    {
        character = opponent = new OpponentModel();
        InitializeCharacter();
    }

    public override CardModel SelectCard()
    {
        // Placeholder for AI logic for selecting a card
        CardModel selectedCard = opponentHandView.SelectCard();
        opponent.SelectedCard = selectedCard;
        return selectedCard;
    }

    public override int AssignPillz()
    {
        int assignedPillz = 3; // Placeholder for AI logic for assigning Pillz
        opponent.SelectedCard.Pillz = assignedPillz;
        return assignedPillz;
    }
}
