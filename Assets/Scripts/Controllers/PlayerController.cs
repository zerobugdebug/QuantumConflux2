using UnityEngine;

public class PlayerController : CharacterController
{
    //public PlayerHandView playerHandView;
    public PlayerModel player;

       void Awake()
    {
        if (characterHandView == null)
        {
            Debug.LogError("PlayerHandView is not assigned in the inspector.");
            return;
        }

        character = player = new PlayerModel();
        //InitializeCharacter();
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
        //player.SelectedCard.Pillz = assignedPillz;
        return assignedPillz;
    }
}
