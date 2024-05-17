using UnityEngine;

[CreateAssetMenu(menuName = "GameStates/CheckGameEndState")]
public class CheckGameEndState : GameStateModel
{
    public override void OnEnter(GameController gameController)
    {
        if (gameController.IsGameOver())
        {
            gameController.GameStateController.SetState(gameController.EndGameState, gameController);
        }
        else
        {
            gameController.GameStateController.SetState(gameController.TurnState, gameController);
        }
    }

    public override void OnExit(GameController gameController) { }

    public override void OnUpdate(GameController gameController) { }
}