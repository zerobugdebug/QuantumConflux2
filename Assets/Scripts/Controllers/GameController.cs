using UnityEngine;

public enum PlayerType
{
    Player,
    Opponent
}

public class GameController : MonoBehaviour
{
    public GameStateController GameStateController;
    public GameStateModel SetupGameState;
    public GameStateModel SelectStartingPlayerState;
    public GameStateModel TurnState;
    public GameStateModel ResolveRoundState;
    public GameStateModel SwitchRolesState;
    public GameStateModel CheckGameEndState;
    public GameStateModel EndGameState;

    public PlayerType CurrentTurnPlayer { get; private set; }
    public bool TurnFinished { get; private set; }

    void Start()
    {
        GameStateController.SetState(SetupGameState, this);
    }

    public void InitializeGame()
    {
        // Initialize game logic
    }

    public void SelectStartingPlayer()
    {
        // Randomly select the starting player
        CurrentTurnPlayer = (Random.value > 0.5f) ? PlayerType.Player : PlayerType.Opponent;
    }

    public void StartTurn()
    {
        // Logic for starting a turn
        TurnFinished = false;
    }

    public void ResolveRound()
    {
        // Logic for resolving the round
    }

    public void SwitchRoles()
    {
        // Swap the roles of attacker and defender
        CurrentTurnPlayer = (CurrentTurnPlayer == PlayerType.Player) ? PlayerType.Opponent : PlayerType.Player;
    }

    public bool IsGameOver()
    {
        // Check if the game is over
        return false;
    }

    public void ShowGameResults()
    {
        // Display the game results
    }
}
