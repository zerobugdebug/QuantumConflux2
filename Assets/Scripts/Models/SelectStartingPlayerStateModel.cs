using UnityEngine;

[CreateAssetMenu(menuName = "GameStates/SelectStartingPlayerState")]
public class SelectStartingPlayerStateModel : GameStateModel
{
    public override void OnEnter(GameController gameController)
    {
        gameController.SelectStartingPlayer();
        gameController.GameStateController.SetState(gameController.TurnState, gameController);
    }

    public override void OnExit(GameController gameController) { }

    public override void OnUpdate(GameController gameController) { }
}