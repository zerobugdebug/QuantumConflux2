using UnityEngine;

public class PlayerController : CharacterController
{
    public PlayerHandView playerHandView;
    public PlayerModel player;

    void Start()
    {
        character = player = new PlayerModel();
        InitializeCharacter();
    }

    public override CardModel SelectCard()
    {
        CardModel selectedCard = playerHandView.SelectCard();
        player.SelectedCard = selectedCard;
        return selectedCard;
    }

    public override int AssignPillz()
    {
        int assignedPillz = 3; // Placeholder for actual Pillz assignment logic
        player.SelectedCard.Pillz = assignedPillz;
        return assignedPillz;
    }
}
