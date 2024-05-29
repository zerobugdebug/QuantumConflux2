using DG.Tweening;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    DefenderPlayCard,
    StartTurn
}

public class GameController : MonoBehaviour
{
    public GameStateController gameStateController;

    [SerializeField] private TextMeshProUGUI fullScreenText; // Reference to the UI Text element

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

    public int TurnNumber { get; private set; }

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
        // Initialize game logic, set initial life points, etc.
        cardDBController.Initialize(new CardDBModel());
        TurnNumber = 1;
        // Initialize player and opponent
        playerController.Initialize(new CharacterModel(), "Player");
        opponentController.Initialize(new CharacterModel(), "Opponent");

        // Initialize player and opponent decks
        DeckController playerDeck = new();
        for (int i = 0 ; i < 8 ; i++)
        {
            playerDeck.AddCard(cardDBController.GetRandomCard());
        }

        playerController.AddDeck(playerDeck);
        playerController.SelectDeck(playerDeck);

        DeckController opponentDeck = new();
        for (int i = 0 ; i < 8 ; i++)
        {
            opponentDeck.AddCard(cardDBController.GetRandomCard());
        }

        opponentController.AddDeck(opponentDeck);
        opponentController.SelectDeck(opponentDeck);

        // Initialize player and opponent hands
        playerController.GenerateHand();
        opponentController.GenerateHand();

        // Update hands views
        playerController.UpdateView();
        opponentController.UpdateView();
        Debug.Log("Game Initialized");

    }

    public void SelectStartingPlayer()
    {
        // Randomly select the starting player
        CurrentTurnPlayer = (UnityEngine.Random.value > 0.5f) ? PlayerType.Player : PlayerType.Opponent;

        //Fix player as first starting for testing
        CurrentTurnPlayer = PlayerType.Player;

        Debug.Log("Starting player selected: " + CurrentTurnPlayer);
    }

    public void StartTurn()
    {
        // Logic for starting a turn
        TurnFinished = false;
        CharacterController attacker = GetCurrentAttacker();
        CharacterController defender = GetCurrentDefender();
        attacker.SetReady(false);
        defender.SetReady(false);
        DisplayPhaseText(attacker.GetName() + " ATTACKS", TurnPhase.AttackerChooseCard);
        Debug.Log(attacker.GetName() + " attacking");
    }

    public void EndTurn()
    {
        // Logic for ending a turn
        TurnFinished = true;
        TurnNumber++;
        Debug.Log(CurrentTurnPlayer + "'s turn ended.");
    }

    public void ResolveRound()
    {
        // Logic for resolving the round, e.g., comparing card powers, updating life points
        CharacterController attacker = GetCurrentAttacker();
        CharacterController defender = GetCurrentDefender();

        int attackerAttack = attacker.CalculateAttack();
        Debug.Log("attackerAttack = " + attackerAttack);
        int defenderAttack = defender.CalculateAttack();
        Debug.Log("defenderAttack = " + defenderAttack);

        if (attackerAttack >= defenderAttack)
        {
            int remainingLifePoints = defender.ApplyDamage(attacker);
            Debug.Log(attacker.GetName() + " wins the round. " + defender.GetName() + " has " + remainingLifePoints + " left");
            DisplayStateText(attacker.GetName() + " wins the round. ", switchRolesState);
        }
        else
        {
            int remainingLifePoints = attacker.ApplyDamage(defender);
            Debug.Log(defender.GetName() + " wins the round. " + attacker.GetName() + " has " + remainingLifePoints + " left");
            DisplayStateText(defender.GetName() + " wins the round. ", switchRolesState);
        }

        playerController.GetCurrentCard().GetCardView().MoveCardUp(false);
        opponentController.GetCurrentCard().GetCardView().MoveCardUp(true);
        attacker.UpdateView();
        defender.UpdateView();
        attacker.ResetSelectedCard();
        defender.ResetSelectedCard();
        CurrentPhase = TurnPhase.StartTurn;
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
        if (playerController.GetLifePoints() <= 0)
        {
            Debug.Log("Game Over. Opponent wins!");
            return true;
        }
        else if (opponentController.GetLifePoints() <= 0)
        {
            Debug.Log("Game Over. Player wins!");
            return true;
        }
        else if (playerController.SelectRandomUnplayedCard() == null)
        {
            Debug.Log("Game Over. No cards available!");
            if (playerController.GetLifePoints() < opponentController.GetLifePoints())
            {
                Debug.Log("Opponent wins!");
            }
            else if (playerController.GetLifePoints() > opponentController.GetLifePoints())
            {
                Debug.Log("Player wins!");
            }
            else
            {
                Debug.Log("Tie game.");
            }
            return true;
        }
        return false;
    }

    public string GetEndGameMessage()
    {
        // Check if the game is over (e.g., if any player's life points reach zero)
        if (playerController.GetLifePoints() <= 0)
        {
            return "Opponent wins!";
        }
        else if (opponentController.GetLifePoints() <= 0)
        {
            return "Player wins!";
        }
        else if (playerController.SelectRandomUnplayedCard() == null)
        {
            return playerController.GetLifePoints() < opponentController.GetLifePoints()
                ? "Opponent wins!"
                : playerController.GetLifePoints() > opponentController.GetLifePoints() ? "Player wins!" : "Tie game.";
        }
        return "";
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
        SceneManager.LoadScene("MainMenu");
    }

    public CharacterController GetCurrentAttacker()
    {
        return CurrentTurnPlayer == PlayerType.Player ? playerController : opponentController;
    }

    public CharacterController GetCurrentDefender()
    {
        return CurrentTurnPlayer == PlayerType.Player ? opponentController : playerController;
    }

    /*    public void DisplayFullScreenText(string message)
        {
            fullScreenText.text = message;
            fullScreenText.gameObject.SetActive(true);
            _ = fullScreenText.DOFade(1, 1f).SetEase(Ease.InOutQuad); // Fade in over 1 second
        }

        public void HideFullScreenText()
        {
            _ = fullScreenText.DOFade(0, 1f).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                fullScreenText.gameObject.SetActive(false);
            }); // Fade out over 1 second

        }

        public void DisplayOpponentPhaseText()
        {
            _ = StartCoroutine(DisplayOpponentPhaseTextCoroutine());
        }

        public IEnumerator DisplayOpponentPhaseTextCoroutine()
        {
            // Display text logic here
            DisplayFullScreenText("Opponent Phase");

            yield return new WaitForSeconds(1);

            // Hide text and move to next phase
            HideFullScreenText();
            yield return new WaitForSeconds(1);
            CurrentPhase = TurnPhase.DefenderChooseCard;

        }
    */
    // Public method to display a full-screen message
    public async void DisplayPhaseText(string message, TurnPhase phase)
    {

        fullScreenText.text = message; // Set the message text
        fullScreenText.gameObject.SetActive(true); // Make the text visible

        await fullScreenText.DOFade(1, 1f).SetEase(Ease.InOutQuad).AsyncWaitForCompletion(); // Fade in over 1 second
        await Task.Delay(1000); // Wait for 1 second
        //await fullScreenText.DOFade(0, 1f).SetEase(Ease.InOutQuad).AsyncWaitForCompletion(); // Fade out over 1 second

        Color color = fullScreenText.color;
        color.a = 0;
        fullScreenText.color = color;

        fullScreenText.gameObject.SetActive(false); // Hide the text after fading out
        //await Task.Delay(1000); // Wait for another second
        CurrentPhase = phase;
    }
    public async void DisplayStateText(string message, GameStateModel state)
    {

        fullScreenText.text = message; // Set the message text
        fullScreenText.gameObject.SetActive(true); // Make the text visible

        await fullScreenText.DOFade(1, 1f).SetEase(Ease.InOutQuad).AsyncWaitForCompletion(); // Fade in over 1 second
        await Task.Delay(1000); // Wait for 1 second
        //await fullScreenText.DOFade(0, 1f).SetEase(Ease.InOutQuad).AsyncWaitForCompletion(); // Fade out over 1 second
        Color color = fullScreenText.color;
        color.a = 0;
        fullScreenText.color = color;

        fullScreenText.gameObject.SetActive(false); // Hide the text after fading out
        //await Task.Delay(1000); // Wait for another second
        gameStateController.SetState(state, this);
    }
}
