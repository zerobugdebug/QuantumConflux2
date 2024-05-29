using UnityEngine;

[CreateAssetMenu(menuName = "GameStates/TurnState")]
public class TurnStateModel : GameStateModel
{
    public override void OnEnter(GameController gameController)
    {
        gameController.StartTurn();
        //gameController.CurrentPhase = TurnPhase.AttackerChooseCard;
    }

    public override void OnExit(GameController gameController) { }

    public override void OnUpdate(GameController gameController)
    {
        if (!gameController.TurnFinished)
        {
            switch (gameController.CurrentPhase)
            {
                case TurnPhase.AttackerChooseCard:
                    AttackerChooseCard(gameController);
                    break;
                case TurnPhase.AttackerAssignPillz:
                    AttackerAssignPillz(gameController);
                    // gameController.CurrentPhase = TurnPhase.AttackerPlayCard;
                    break;
                case TurnPhase.AttackerPlayCard:
                    AttackerPlayCard(gameController);
                    break;
                case TurnPhase.DefenderChooseCard:
                    DefenderChooseCard(gameController);
                    break;
                case TurnPhase.DefenderAssignPillz:
                    DefenderAssignPillz(gameController);
                    break;
                case TurnPhase.DefenderPlayCard:
                    DefenderPlayCard(gameController);

                    break;
            }
        }
        else
        {
            gameController.gameStateController.SetState(gameController.fightDisplayState, gameController);
        }
    }

    private void AttackerChooseCard(GameController gameController)
    {
        CharacterController attacker = gameController.GetCurrentAttacker();
        if (attacker.IsCardSelected())
        {
            gameController.CurrentPhase = TurnPhase.AttackerAssignPillz;
        }
        else if (!attacker.IsReady() && gameController.CurrentTurnPlayer == PlayerType.Player)
        {
            attacker.SubscribeToCardClicked();
            attacker.SetReady(true);
        }
        else if (gameController.CurrentTurnPlayer == PlayerType.Opponent)

        {
            gameController.GetCurrentDefender().UnSubscribeToCardClicked();
            attacker.SetReady(true);
            CardController selectedCard = attacker.SelectCard();
            Debug.Log("Attacker has chosen card: " + selectedCard.GetName());
        }
        //attacker.character.SelectedCard = selectedCard;
        //Debug.Log("Attacker has chosen card: " + selectedCard.name);
    }

    private void AttackerAssignPillz(GameController gameController)
    {
        CharacterController attacker = gameController.GetCurrentAttacker();
        if (attacker.IsCurrentCardPillzAssigned())
        {
            Debug.Log("Attacker has assigned " + attacker.GetAssignedPillz() + " Pillz to card: " + attacker.GetCurrentCard().GetName());
            gameController.CurrentPhase = TurnPhase.AttackerPlayCard;
        }
        else
        {
            attacker.AssignPillz();
        }
    }

    private void AttackerPlayCard(GameController gameController)
    {
        CharacterController attacker = gameController.GetCurrentAttacker();
        CardController card = attacker.GetCurrentCard();
        if (!card.IsPlayed)
        {
            Debug.Log("Attacker plays card: " + card.GetName());
            card.IsPlayed = true;
            attacker.ResetChargeAssignment();

            // Highlight the selected card
            //card.GetCardView().HighlightCard(true);

            // Move the card up
            attacker.MarkCard();

            // Display next phase text
            gameController.DisplayPhaseText(gameController.GetCurrentDefender().GetName() + " DEFENDS", TurnPhase.DefenderChooseCard);
        }
    }

    private void DefenderChooseCard(GameController gameController)
    {
        //CharacterController defender = gameController.GetCurrentDefender();
        //CardController selectedCard = defender.SelectCard();
        //defender.character.SelectedCard = selectedCard;
        //Debug.Log("Defender has chosen card: " + selectedCard.GetName());

        CharacterController defender = gameController.GetCurrentDefender();
        if (defender.IsCardSelected())
        {
            gameController.CurrentPhase = TurnPhase.DefenderAssignPillz;
        }
        else if (!defender.IsReady() && gameController.CurrentTurnPlayer == PlayerType.Opponent)
        {
            defender.SubscribeToCardClicked();
            defender.SetReady(true);
        }
        else if (gameController.CurrentTurnPlayer == PlayerType.Player)

        {
            gameController.GetCurrentAttacker().UnSubscribeToCardClicked();
            defender.SetReady(true);
            CardController selectedCard = defender.SelectCard();
            Debug.Log("Defender has chosen card: " + selectedCard.GetName());
        }
    }

    private void DefenderAssignPillz(GameController gameController)
    {
        CharacterController defender = gameController.GetCurrentDefender();
        if (defender.IsCurrentCardPillzAssigned())
        {
            Debug.Log("Attacker has assigned " + defender.GetAssignedPillz() + " Pillz to card: " + defender.GetCurrentCard().GetName());
            gameController.CurrentPhase = TurnPhase.DefenderPlayCard;
        }
        else
        {
            defender.AssignPillz();
        }
        //int assignedPillz = defender.AssignPillz();
        //defender.character.SelectedCard.Pillz = assignedPillz;
        //defender.character.Pillz -= assignedPillz;
        //Debug.Log("Defender has assigned " + assignedPillz + " Pillz to card: " + assignedPillz);
    }

    private void DefenderPlayCard(GameController gameController)
    {

        CharacterController defender = gameController.GetCurrentDefender();
        CardController card = defender.GetCurrentCard();

        if (!card.IsPlayed)
        {
            Debug.Log("Defender plays card: " + card.GetName());
            card.IsPlayed = true;
            defender.ResetChargeAssignment();

            // Highlight the selected card
            //card.GetCardView().HighlightCard(true);

            // Move the card up
            defender.MarkCard();

            gameController.EndTurn();

            // Display next phase text
            //gameController.DisplayPhaseText(gameController.GetCurrentDefender().GetName() + " PHASE", TurnPhase.DefenderChooseCard);
        }
    }
}