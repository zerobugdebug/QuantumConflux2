using UnityEngine;

public class OpponentController : CharacterController
{
    //public OpponentHandView opponentHandView;
    //public OpponentModel opponentModel;

    private void Awake()
    {
        if (characterHandView == null)
        {
            Debug.LogError("OpponentHandView is not assigned in the inspector.");
            return;
        }

        characterModel = new OpponentModel();
        SetName("Opponent");
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
        int pillz = Random.Range(0, GetPillz());
        selectedCard.SetPillz(pillz);
        characterModel.RemovePillz(pillz);
        //return assignedPillz;
    }

    public override void ConfirmPillzSelection(int value)
    {
        //selectedCard.SetPillz(value);
    }

    public override void ResetChargeAssignment()
    {

    }

    public override void MarkCard()
    {
        selectedCard.GetCardView().MoveCardUp(false);
    }
}
