using UnityEngine;

[CreateAssetMenu(menuName = "GameStates/CheckGameEndState")]
public class CheckGameEndStateModel : GameStateModel
{
    public override void OnEnter(GameController gameController)
    {
        if (gameController.IsGameOver())
        {
            gameController.DisplayStateText(gameController.GetEndGameMessage(), gameController.endGameState);
            //gameController.gameStateController.SetState(gameController.endGameState, gameController);
        }
        else
        {
            gameController.DisplayStateText("TURN: " + gameController.TurnNumber, gameController.turnState);
            //gameController.gameStateController.SetState(gameController.turnState, gameController);
        }
    }

    public override void OnExit(GameController gameController) { }

    public override void OnUpdate(GameController gameController) { }
}