using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    IN_GAME,
    PAUSED,
    DRAW_GAME,
    WIN_GAME
}

public class GameController : MonoBehaviour
{
    private GameState _currentState; 
    public GameState GetCurrentState => _currentState;
     
    public UnityAction<GameState> StateChanged;  

    public void SetGameState(GameState state)
    {
        _currentState = state; 
        StateChanged?.Invoke(state);
    } 
}
