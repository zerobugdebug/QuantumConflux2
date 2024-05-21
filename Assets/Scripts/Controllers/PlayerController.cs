using UnityEngine;

public class PlayerController : CharacterController
{
    public PlayerModel playerModel;

    void Awake()
    {
        if (characterHandView == null)
        {
            Debug.LogError("PlayerHandView is not assigned in the inspector.");
            return;
        }

        characterModel = playerModel = new PlayerModel();
    }

    public override CardController SelectCard()
    {
        CardController selectedCard = characterHandView.SelectCard();
        this.selectedCard = selectedCard;
        return selectedCard;
    }

    public override int AssignPillz()
    {
        int assignedPillz = 3; // Placeholder for actual Pillz assignment logic
        return assignedPillz;
    }
}
