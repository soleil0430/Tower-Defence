using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BuilderState
{
    public class BuilderStateMachine : StateMachine<Builder>
    {
        protected override void InitState()
        {
            MoveState moveState = new MoveState();
            StandState standState = new StandState();
            BuildState buildState = new BuildState();

            stateDictionary.Add(moveState.name, moveState);
            stateDictionary.Add(standState.name, standState);
            stateDictionary.Add(buildState.name, buildState);

            //Move -> Stand
            Transition<Builder> move_toStand = new Transition<Builder>(standState);
            move_toStand.doCheck += () => { return Input.GetKeyDown(KeyCode.Space); };
            moveState.AddTransition(move_toStand);

            //Stand -> Move
            Transition<Builder> stand_toMove = new Transition<Builder>(moveState);
            stand_toMove.doCheck += () => { return Input.GetKeyDown(KeyCode.Space); };
            standState.AddTransition(stand_toMove);

            //Stand -> Build
            Transition<Builder> stand_selectTower = new Transition<Builder>(buildState);
            stand_selectTower.doCheck += () => { return (entity.selectTower != null); };
            standState.AddTransition(stand_selectTower);

            //Build -> Stand
            Transition<Builder> build_cancelTower = new Transition<Builder>(standState);
            build_cancelTower.doCheck += () => { return (entity.cancelBuildMode == true); };
            buildState.AddTransition(build_cancelTower);

            nowState = moveState;
        }
    }
}