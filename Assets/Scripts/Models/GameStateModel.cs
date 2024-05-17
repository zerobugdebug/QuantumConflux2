using UnityEngine;

public abstract class GameStateModel : ScriptableObject
{
    public abstract void OnEnter(GameController gameController);
    public abstract void OnExit(GameController gameController);
    public abstract void OnUpdate(GameController gameController);
}

[CreateAssetMenu(menuName = "GameStates/SetupGameState")]
public class SetupGameState : GameStateModel
{
    public override void OnEnter(GameController gameController)
    {
        gameController.InitializeGame();
        gameController.GameStateController.SetState(gameController.SelectStartingPlayerState, gameController);
    }

    public override void OnExit(GameController gameController) { }

    public override void OnUpdate(GameController gameController) { }
}

[CreateAssetMenu(menuName = "GameStates/SelectStartingPlayerState")]
public class SelectStartingPlayerState : GameStateModel
{
    public override void OnEnter(GameController gameController)
    {
        gameController.SelectStartingPlayer();
        gameController.GameStateController.SetState(gameController.TurnState, gameController);
    }

    public override void OnExit(GameController gameController) { }

    public override void OnUpdate(GameController gameController) { }
}


[CreateAssetMenu(menuName = "GameStates/TurnState")]
public class TurnState : GameStateModel
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

[CreateAssetMenu(menuName = "GameStates/ResolveRoundState")]
public class ResolveRoundState : GameStateModel
{
    public override void OnEnter(GameController gameController)
    {
        gameController.ResolveRound();
        gameController.GameStateController.SetState(gameController.SwitchRolesState, gameController);
    }

    public override void OnExit(GameController gameController) { }

    public override void OnUpdate(GameController gameController) { }
}

[CreateAssetMenu(menuName = "GameStates/SwitchRolesState")]
public class SwitchRolesState : GameStateModel
{
    public override void OnEnter(GameController gameController)
    {
        gameController.SwitchRoles();
        gameController.GameStateController.SetState(gameController.CheckGameEndState, gameController);
    }

    public override void OnExit(GameController gameController) { }

    public override void OnUpdate(GameController gameController) { }
}

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

[CreateAssetMenu(menuName = "GameStates/EndGameState")]
public class EndGameState : GameStateModel
{
    public override void OnEnter(GameController gameController)
    {
        gameController.ShowGameResults();
    }

    public override void OnExit(GameController gameController) { }

    public override void OnUpdate(GameController gameController) { }
}
