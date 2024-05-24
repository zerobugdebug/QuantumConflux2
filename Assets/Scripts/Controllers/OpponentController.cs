using UnityEngine;

public class OpponentController : CharacterController
{
    //public OpponentHandView opponentHandView;
    public OpponentModel opponentModel;

    private void Awake()
    {
        if (characterHandView == null)
        {
            Debug.LogError("OpponentHandView is not assigned in the inspector.");
            return;
        }

        characterModel = opponentModel = new OpponentModel();
        // Initialize();
    }

    public override CardController SelectCard()
    {
        // Placeholder for AI logic for selecting a card
        CardController selectedCard = SelectRandomUnplayedCard();
        this.selectedCard = selectedCard;
        return selectedCard;
    }

    public override void AssignPillz()
    {
        //opponent.SelectedCard.Pillz = assignedPillz;
        //return assignedPillz;
    }

    public override void ConfirmPillzSelection(int value)
    {
        //selectedCard.SetPillz(value);
    }
}
