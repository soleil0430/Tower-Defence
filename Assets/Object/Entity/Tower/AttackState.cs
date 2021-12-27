using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TowerState
{
    public class AttackState : State<Tower>
    {
        public AttackState() { name = "Attack"; }

        protected override void OnEnter(Tower entity)
        {

        }

        protected override void OnExit(Tower entity)
        {

        }

        protected override void OnUpdate(Tower entity)
        {
            entity.Attack();
        }
    }
}