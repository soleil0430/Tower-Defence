using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GoblinState
{
    public class GoblinStateMachine : StateMachine<Goblin>
    {
        protected override void InitState()
        {
            IdleState idleState = new IdleState();
            MoveState moveState = new MoveState();

            stateDictionary.Add(idleState.name, idleState);
            stateDictionary.Add(moveState.name, moveState);

            nowState = idleState;
        }
    }
}