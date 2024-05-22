using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public GameController game;  // Public variable for GameController

    private GameStateModel currentState;

    public void SetState(GameStateModel newState, GameController game)
    {
        if (currentState != null)
        {
            Debug.Log("Exiting state: " + currentState);
            currentState.OnExit(game);
        }

        currentState = newState;

        if (currentState != null)
        {
            Debug.Log("Entering state: " + currentState);
            currentState.OnEnter(game);
        }
    }

    void Update()
    {
        if (game == null)
        {
            Debug.LogError("GameController reference is not set in the inspector.");
            return;
        }

        if (currentState != null)
        {
            currentState.OnUpdate(game);
        }
    }
}
