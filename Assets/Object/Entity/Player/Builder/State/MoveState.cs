using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BuilderState
{
    public class MoveState : State<Builder>
    {
        public MoveState() { name = "Move"; tagHash = Animator.StringToHash(name); }

        protected override void OnEnter(Builder entity)
        {

        }

        protected override void OnExit(Builder entity)
        {

        }

        protected override void OnUpdate(Builder entity)
        {
            entity.InputMoveDirection();
            entity.InputMoveSpeed();
            entity.InputCameraRotation();

            entity.Move();
            entity.Rotate();
        }
    }
}