using UnityEngine;

[CreateAssetMenu(menuName = "GameStates/ResolveRoundState")]
public class ResolveRoundStateModel : GameStateModel
{
    public override void OnEnter(GameController gameController)
    {
        gameController.ResolveRound();
        gameController.gameStateController.SetState(gameController.switchRolesState, gameController);
    }

    public override void OnExit(GameController gameController) { }

    public override void OnUpdate(GameController gameController) { }
}