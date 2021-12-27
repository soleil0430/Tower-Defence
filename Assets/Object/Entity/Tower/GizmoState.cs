using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TowerState
{
    public class GizmoState : State<Tower>
    {
        public GizmoState() { name = "Gizmo"; }
        protected override void OnEnter(Tower entity)
        {

        }

        protected override void OnExit(Tower entity)
        {

        }

        protected override void OnUpdate(Tower entity)
        {
            entity.CheckCanBuild();

            if (entity.isCanBuild)
                entity.material.color = Color.green;
            else
                entity.material.color = Color.red;
        }
    }
}