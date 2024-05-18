using UnityEngine;

public enum PlayerType
{
    Player,
    Opponent
}

public class GameController : MonoBehaviour
{
    public GameStateController GameStateController;

    // References to GameState ScriptableObjects
    public GameStateModel SetupGameState;
    public GameStateModel SelectStartingPlayerState;
    public GameStateModel TurnState;
    public GameStateModel ResolveRoundState;
    public GameStateModel SwitchRolesState;
    public GameStateModel CheckGameEndState;
    public GameStateModel EndGameState;

    // Game-specific variables
    public PlayerType CurrentTurnPlayer { get; private set; }
    public bool TurnFinished { get; private set; }
    public int PlayerLifePoints { get; private set; }
    public int OpponentLifePoints { get; private set; }

    public PlayerController playerController;
    public OpponentController opponentController;
    public CardController cardController;

    void Start()
    {
        GameStateController.SetState(SetupGameState, this);
    }

    public void InitializeGame()
    {
        // Initialize game logic, set initial life points, etc.
        PlayerLifePoints = 12;
        OpponentLifePoints = 12;
        Debug.Log("Game Initialized");
        
        // Initialize player and opponent hands
        cardController.InstantiateHand(playerController.player.Hand, playerController.playerHandView);
        cardController.InstantiateHand(opponentController.opponent.Hand, opponentController.opponentHandView);

    }

    public void SelectStartingPlayer()
    {
        // Randomly select the starting player
        CurrentTurnPlayer = (Random.value > 0.5f) ? PlayerType.Player : PlayerType.Opponent;
        Debug.Log("Starting player selected: " + CurrentTurnPlayer);
    }

    public void StartTurn()
    {
        // Logic for starting a turn
        TurnFinished = false;
        Debug.Log(CurrentTurnPlayer + "'s turn started.");
    }

    public void EndTurn()
    {
        // Logic for ending a turn
        TurnFinished = true;
        Debug.Log(CurrentTurnPlayer + "'s turn ended.");
    }

    public void ResolveRound()
    {
        // Logic for resolving the round, e.g., comparing card powers, updating life points
        int playerAttack = CalculatePlayerAttack();
        int opponentAttack = CalculateOpponentAttack();

        if (playerAttack > opponentAttack)
        {
            OpponentLifePoints -= 2; // Example damage value
            Debug.Log("Player wins the round. Opponent loses 2 life points.");
        }
        else if (opponentAttack > playerAttack)
        {
            PlayerLifePoints -= 2; // Example damage value
            Debug.Log("Opponent wins the round. Player loses 2 life points.");
        }
        else
        {
            Debug.Log("Round is a tie.");
        }
    }

    public void SwitchRoles()
    {
        // Swap the roles of attacker and defender
        CurrentTurnPlayer = (CurrentTurnPlayer == PlayerType.Player) ? PlayerType.Opponent : PlayerType.Player;
        Debug.Log("Roles switched. New attacker: " + CurrentTurnPlayer);
    }

    public bool IsGameOver()
    {
        // Check if the game is over (e.g., if any player's life points reach zero)
        if (PlayerLifePoints <= 0)
        {
            Debug.Log("Game Over. Opponent wins!");
            return true;
        }
        else if (OpponentLifePoints <= 0)
        {
            Debug.Log("Game Over. Player wins!");
            return true;
        }

        return false;
    }

    public void ShowGameResults()
    {
        // Display the game results
        Debug.Log("Displaying game results.");
        if (PlayerLifePoints <= 0)
        {
            Debug.Log("Opponent wins!");
        }
        else if (OpponentLifePoints <= 0)
        {
            Debug.Log("Player wins!");
        }
        else
        {
            Debug.Log("Game ended with no clear winner.");
        }
    }

    private int CalculatePlayerAttack()
    {
        // Example calculation of player attack value
        // This would typically involve the card played and the number of pillz assigned
        return Random.Range(1, 10); // Placeholder for actual calculation
    }

    private int CalculateOpponentAttack()
    {
        // Example calculation of opponent attack value
        // This would typically involve the card played and the number of pillz assigned
        return Random.Range(1, 10); // Placeholder for actual calculation
    }

    public CharacterController GetCurrentAttacker()
    {
        return CurrentTurnPlayer == PlayerType.Player ? playerController : opponentController;
    }

    public CharacterController GetCurrentDefender()
    {
        return CurrentTurnPlayer == PlayerType.Player ? opponentController : playerController;
    }

}
