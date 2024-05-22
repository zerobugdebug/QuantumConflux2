using UnityEngine;

public enum PlayerType
{
    Player,
    Opponent
}

public enum TurnPhase
{
    AttackerChooseCard,
    AttackerAssignPillz,
    AttackerPlayCard,
    DefenderChooseCard,
    DefenderAssignPillz,
    DefenderPlayCard
}

public class GameController : MonoBehaviour
{
    public GameStateController gameStateController;

    // References to GameState ScriptableObjects
    public SetupGameStateModel setupGameState;
    public SelectStartingPlayerStateModel selectStartingPlayerState;
    public TurnStateModel turnState;
    public ResolveRoundStateModel resolveRoundState;
    public SwitchRolesStateModel switchRolesState;
    public CheckGameEndStateModel checkGameEndState;
    public EndGameStateModel endGameState;

    public TurnPhase CurrentPhase { get; set; }

    // Game-specific variables
    public PlayerType CurrentTurnPlayer { get; private set; }
    public bool TurnFinished { get; private set; }
    public int PlayerLifePoints { get; private set; }
    public int OpponentLifePoints { get; private set; }

    public PlayerController playerController;
    public OpponentController opponentController;
    public CardDBController cardDBController;

    private void Start()
    {
        if (gameStateController == null || playerController == null || opponentController == null || cardDBController == null)
        {
            Debug.LogError("One or more required components are not assigned in the inspector.");
            return;
        }
        gameStateController.SetState(setupGameState, this);
    }

    public void InitializeGame()
    {
        cardDBController.Initialize(new CardDBModel());

        // Initialize game logic, set initial life points, etc.
        PlayerLifePoints = 12;
        OpponentLifePoints = 12;
        Debug.Log("Game Initialized");

        // Initialize player and opponent
        playerController.Initialize(new CharacterModel());
        opponentController.Initialize(new CharacterModel());

        // Initialize player and opponent decks
        DeckController deck = new();
        deck.AddCard(cardDBController.GetCardById(0));
        deck.AddCard(cardDBController.GetCardById(1));
        deck.AddCard(cardDBController.GetCardById(2));
        deck.AddCard(cardDBController.GetCardById(3));
        deck.AddCard(cardDBController.GetCardById(4));
        deck.AddCard(cardDBController.GetCardById(5));
        deck.AddCard(cardDBController.GetCardById(6));
        deck.AddCard(cardDBController.GetCardById(7));

        playerController.AddDeck(deck);
        playerController.SelectDeck(deck);
        opponentController.AddDeck(deck);
        opponentController.SelectDeck(deck);

        // Initialize player and opponent hands
        playerController.GenerateHand();
        opponentController.GenerateHand();

        //TODO: call instantiate for all cards on hand.

        // Update hands views
        playerController.UpdateView();
        opponentController.UpdateView();

    }

    public void SelectStartingPlayer()
    {
        // Randomly select the starting player
        CurrentTurnPlayer = (Random.value > 0.5f) ? PlayerType.Player : PlayerType.Opponent;

        //Fix player as first starting for testing
        CurrentTurnPlayer = PlayerType.Player;

        Debug.Log("Starting player selected: " + CurrentTurnPlayer);
    }

    public void StartTurn()
    {
        // Logic for starting a turn
        TurnFinished = false;
        CurrentPhase = TurnPhase.AttackerChooseCard;
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
