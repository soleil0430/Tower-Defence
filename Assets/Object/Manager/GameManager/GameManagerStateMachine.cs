using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManagerState;

public class GameManagerStateMachine : StateMachine<GameManager>
{
    protected override void InitState()
    {
        PauseState pauseState = new PauseState();
        GameState gameState = new GameState();

        stateDictionary.Add(pauseState.name, pauseState);
        stateDictionary.Add(gameState.name, gameState);


        nowState = gameState;
    }
}
