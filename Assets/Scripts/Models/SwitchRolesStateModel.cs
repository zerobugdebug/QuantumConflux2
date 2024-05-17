using UnityEngine;

[CreateAssetMenu(menuName = "GameStates/SwitchRolesState")]
public class SwitchRolesStateModel : GameStateModel
{
    public override void OnEnter(GameController gameController)
    {
        gameController.SwitchRoles();
        gameController.GameStateController.SetState(gameController.CheckGameEndState, gameController);
    }

    public override void OnExit(GameController gameController) { }

    public override void OnUpdate(GameController gameController) { }
}
