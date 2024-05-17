using UnityEngine;

[CreateAssetMenu(menuName = "GameStates/EndGameState")]
public class EndGameStateModel : GameStateModel
{
    public override void OnEnter(GameController gameController)
    {
        gameController.ShowGameResults();
    }

    public override void OnExit(GameController gameController) { }

    public override void OnUpdate(GameController gameController) { }
}
