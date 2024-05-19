using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public GameController gameController;  // Public variable for GameController

    private GameStateModel currentState;

    public void SetState(GameStateModel newState, GameController gameController)
    {
        if (currentState != null)
        {
            currentState.OnExit(gameController);
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.OnEnter(gameController);
        }
    }

    void Update()
    {
        if (gameController == null)
        {
            Debug.LogError("GameController reference is not set in the inspector.");
            return;
        }

        if (currentState != null)
        {
            currentState.OnUpdate(gameController);
        }
    }
}
