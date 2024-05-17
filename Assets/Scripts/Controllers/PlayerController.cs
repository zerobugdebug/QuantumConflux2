using UnityEngine;

public class PlayerController : CharacterController
{
    public PlayerHandView playerHandView;

    void Start()
    {
        InitializeCharacter();
    }

    public override CardModel SelectCard()
    {
        CardModel selectedCard = playerHandView.SelectCard();
        character.SelectedCard = selectedCard;
        return selectedCard;
    }

    public override int AssignPillz()
    {
        int assignedPillz = 3; // Placeholder for actual Pillz assignment logic
        character.SelectedCard.Pillz = assignedPillz;
        return assignedPillz;
    }
}
