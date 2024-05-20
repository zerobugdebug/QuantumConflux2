using UnityEngine;

public class OpponentController : CharacterController
{
    //public OpponentHandView opponentHandView;
    public OpponentModel opponent;

    void Awake()
    {
        if (characterHandView == null)
        {
            Debug.LogError("OpponentHandView is not assigned in the inspector.");
            return;
        }

        character = opponent = new OpponentModel();
       // Initialize();
    }

    public override CardController SelectCard()
    {
        // Placeholder for AI logic for selecting a card
        CardController selectedCard = characterHandView.SelectCard();
        this.selectedCard = selectedCard;
        return selectedCard;
    }

    public override int AssignPillz()
    {
        int assignedPillz = 3; // Placeholder for AI logic for assigning Pillz
        //opponent.SelectedCard.Pillz = assignedPillz;
        return assignedPillz;
    }
}
