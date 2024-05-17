using UnityEngine;

public class GameStateController : MonoBehaviour
{
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
        if (currentState != null)
        {
            currentState.OnUpdate(this.GetComponent<GameController>());
        }
    }
}
