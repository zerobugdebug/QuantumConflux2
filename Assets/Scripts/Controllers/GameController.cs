using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController playerController;
    public OpponentController opponentController;

    void Start()
    {
        // Initialize both players at the start of the game
        playerController.InitializePlayer();
        opponentController.InitializeOpponent();

        StartTurn();
    }

    public void StartTurn()
    {
        // Logic to start the player's turn
    }

    public void EndTurn()
    {
        // Logic to end the player's turn and start the opponent's turn
    }

    // Methods to handle game flow, transitions, etc.
}