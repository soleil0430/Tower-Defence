using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BuilderState
{
    public class StandState : State<Builder>
    {
        public StandState() { name = "Stand"; tagHash = Animator.StringToHash(name); }

        protected override void OnEnter(Builder entity)
        {
        }

        protected override void OnExit(Builder entity)
        {

        }

        protected override void OnUpdate(Builder entity)
        {
            //UI Control
        }
    }
}