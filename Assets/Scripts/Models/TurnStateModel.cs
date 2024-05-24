using UnityEngine;

[CreateAssetMenu(menuName = "GameStates/TurnState")]
public class TurnStateModel : GameStateModel
{
    public override void OnEnter(GameController gameController)
    {
        gameController.StartTurn();
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
                    gameController.CurrentPhase = TurnPhase.DefenderChooseCard;
                    break;
                case TurnPhase.DefenderChooseCard:
                    DefenderChooseCard(gameController);
                    gameController.CurrentPhase = TurnPhase.DefenderAssignPillz;
                    break;
                case TurnPhase.DefenderAssignPillz:
                    DefenderAssignPillz(gameController);
                    gameController.CurrentPhase = TurnPhase.DefenderPlayCard;
                    break;
                case TurnPhase.DefenderPlayCard:
                    DefenderPlayCard(gameController);
                    gameController.EndTurn();
                    break;
            }
        }
        else
        {
            gameController.gameStateController.SetState(gameController.resolveRoundState, gameController);
        }
    }

    private void AttackerChooseCard(GameController gameController)
    {
        CharacterController attacker = gameController.GetCurrentAttacker();
        if (attacker.IsCardSelected())
        {
            gameController.CurrentPhase = TurnPhase.AttackerAssignPillz;
        }
        //attacker.character.SelectedCard = selectedCard;
        //Debug.Log("Attacker has chosen card: " + selectedCard.name);
    }

    private void AttackerAssignPillz(GameController gameController)
    {
        CharacterController attacker = gameController.GetCurrentAttacker();
        if (attacker.IsCurrentCardPillzAssigned())
        {
            Debug.Log("Attacker has assigned " + attacker.GetAssignedPillz() + " Pillz to card: " + attacker.GetCurrentCard());
            gameController.CurrentPhase = TurnPhase.AttackerPlayCard;
        }
        else
        { attacker.AssignPillz(); }
    }

    private void AttackerPlayCard(GameController gameController)
    {
        CharacterController attacker = gameController.GetCurrentAttacker();
        CardController card = attacker.GetCurrentCard();
        Debug.Log("Attacker plays card: " + card.name);
        // Additional logic for pre-battle abilities can be implemented here.
    }

    private void DefenderChooseCard(GameController gameController)
    {
        CharacterController defender = gameController.GetCurrentDefender();
        CardController selectedCard = defender.SelectCard();
        //defender.character.SelectedCard = selectedCard;
        Debug.Log("Defender has chosen card: " + selectedCard.name);
    }

    private void DefenderAssignPillz(GameController gameController)
    {
        CharacterController defender = gameController.GetCurrentDefender();
        if (defender.IsCurrentCardPillzAssigned())
        {
            Debug.Log("Attacker has assigned " + defender.GetAssignedPillz() + " Pillz to card: " + defender.GetCurrentCard());
            gameController.CurrentPhase = TurnPhase.DefenderPlayCard;
        }
        else
        { defender.AssignPillz(); }
        //int assignedPillz = defender.AssignPillz();
        //defender.character.SelectedCard.Pillz = assignedPillz;
        //defender.character.Pillz -= assignedPillz;
        //Debug.Log("Defender has assigned " + assignedPillz + " Pillz to card: " + assignedPillz);
    }

    private void DefenderPlayCard(GameController gameController)
    {
        CharacterController defender = gameController.GetCurrentDefender();
        CardController card = defender.GetCurrentCard();
        Debug.Log("Defender plays card: " + card.name);
        // Additional logic for pre-battle abilities can be implemented here.
    }
}