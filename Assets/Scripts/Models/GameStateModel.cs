using UnityEngine;

public abstract class GameStateModel : ScriptableObject
{
    public abstract void OnEnter(GameController game);
    public abstract void OnExit(GameController game);
    public abstract void OnUpdate(GameController game);
}
