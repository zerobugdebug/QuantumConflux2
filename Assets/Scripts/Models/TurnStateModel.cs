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
        if (gameController.TurnFinished)
        {
            gameController.GameStateController.SetState(gameController.ResolveRoundState, gameController);
        }
    }
}