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
                    gameController.CurrentPhase = TurnPhase.AttackerAssignPillz;
                    break;
                case TurnPhase.AttackerAssignPillz:
                    AttackerAssignPillz(gameController);
                    gameController.CurrentPhase = TurnPhase.AttackerPlayCard;
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
            gameController.GameStateController.SetState(gameController.ResolveRoundState, gameController);
        }
    }

    private void AttackerChooseCard(GameController gameController)
    {
        CharacterController attacker = gameController.GetCurrentAttacker();
        CardModel selectedCard = attacker.SelectCard();
        attacker.character.SelectedCard = selectedCard;
        Debug.Log("Attacker has chosen card: " + selectedCard.Name);
    }

    private void AttackerAssignPillz(GameController gameController)
    {
        CharacterController attacker = gameController.GetCurrentAttacker();
        int assignedPillz = attacker.AssignPillz();
        attacker.character.SelectedCard.Pillz = assignedPillz;
        attacker.character.Pillz -= assignedPillz;
        Debug.Log("Attacker has assigned " + assignedPillz + " Pillz to card: " + attacker.character.SelectedCard.Name);
    }

    private void AttackerPlayCard(GameController gameController)
    {
        CharacterController attacker = gameController.GetCurrentAttacker();
        CardModel card = attacker.character.SelectedCard;
        Debug.Log("Attacker plays card: " + card.Name);
        // Additional logic for pre-battle abilities can be implemented here.
    }

    private void DefenderChooseCard(GameController gameController)
    {
        CharacterController defender = gameController.GetCurrentDefender();
        CardModel selectedCard = defender.SelectCard();
        defender.character.SelectedCard = selectedCard;
        Debug.Log("Defender has chosen card: " + selectedCard.Name);
    }

    private void DefenderAssignPillz(GameController gameController)
    {
        CharacterController defender = gameController.GetCurrentDefender();
        int assignedPillz = defender.AssignPillz();
        defender.character.SelectedCard.Pillz = assignedPillz;
        defender.character.Pillz -= assignedPillz;
        Debug.Log("Defender has assigned " + assignedPillz + " Pillz to card: " + defender.character.SelectedCard.Name);
    }

    private void DefenderPlayCard(GameController gameController)
    {
        CharacterController defender = gameController.GetCurrentDefender();
        CardModel card = defender.character.SelectedCard;
        Debug.Log("Defender plays card: " + card.Name);
        // Additional logic for pre-battle abilities can be implemented here.
    }
}