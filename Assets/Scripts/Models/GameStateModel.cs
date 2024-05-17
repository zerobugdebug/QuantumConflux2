using UnityEngine;

public abstract class GameStateModel : ScriptableObject
{
    public abstract void OnEnter(GameController gameController);
    public abstract void OnExit(GameController gameController);
    public abstract void OnUpdate(GameController gameController);
}

