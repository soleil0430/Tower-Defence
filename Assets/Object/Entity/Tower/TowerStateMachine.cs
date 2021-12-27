using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TowerState
{
    public class TowerStateMachine : StateMachine<Tower>
    {
        protected override void InitState()
        {
            GizmoState gizmoState = new GizmoState();
            StandState standState = new StandState();
            AttackState attackState = new AttackState();

            stateDictionary.Add(gizmoState.name, gizmoState);
            stateDictionary.Add(standState.name, standState);
            stateDictionary.Add(attackState.name, attackState);

            Transition<Tower> gizmo_toStand = new Transition<Tower>(standState);
            gizmo_toStand.doCheck += () => { return entity.isBuilded == true; };
            gizmoState.AddTransition(gizmo_toStand);

            Transition<Tower> stand_toAttack = new Transition<Tower>(attackState);
            stand_toAttack.doCheck += () => { return entity.target != null; };
            standState.AddTransition(stand_toAttack);

            Transition<Tower> attack_toStand = new Transition<Tower>(standState);
            attack_toStand.doCheck += () => { return entity.target == null; };
            attackState.AddTransition(attack_toStand);

            nowState = gizmoState;
        }
    }
}