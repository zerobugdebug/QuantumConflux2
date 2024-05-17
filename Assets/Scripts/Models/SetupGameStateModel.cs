using UnityEngine;

[CreateAssetMenu(menuName = "GameStates/SetupGameState")]
public class SetupGameStateModel : GameStateModel
{
    public override void OnEnter(GameController gameController)
    {
        gameController.InitializeGame();
        gameController.GameStateController.SetState(gameController.SelectStartingPlayerState, gameController);
    }

    public override void OnExit(GameController gameController) { }

    public override void OnUpdate(GameController gameController) { }
}
