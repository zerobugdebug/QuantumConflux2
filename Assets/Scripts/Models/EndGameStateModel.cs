using UnityEngine;

[CreateAssetMenu(menuName = "GameStates/EndGameState")]
public class EndGameStateModel : GameStateModel
{
    public override void OnEnter(GameController game)
    {
        game.ShowGameResults();
    }

    public override void OnExit(GameController game) { }

    public override void OnUpdate(GameController game) { }
}
