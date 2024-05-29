// Filename: FightDisplayStateModel.cs
using UnityEngine;

[CreateAssetMenu(menuName = "GameStates/FightDisplayState")]
public class FightDisplayStateModel : GameStateModel
{
    public override void OnEnter(GameController gameController)
    {
        gameController.DisplayFight();
    }

    public override void OnExit(GameController gameController) { }

    public override void OnUpdate(GameController gameController) { }
}
