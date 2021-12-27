using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BuilderState
{
    public class BuildState : State<Builder>
    {
        public BuildState() { name = "Build"; tagHash = Animator.StringToHash(name); }

        protected override void OnEnter(Builder entity)
        {
            entity.CreateTowerGizmo();
            entity.buildRotation = new Vector3(0f, entity.cmPlayer.rotation.eulerAngles.y + 180f, 0f);
        }

        protected override void OnExit(Builder entity)
        {
            entity.cancelBuildMode = false;

            if (entity.newTower.isBuilded == false)
                Destroy(entity.newTower.gameObject);

            entity.newTower = null;
            entity.selectTower = null;
        }

        protected override void OnUpdate(Builder entity)
        {
            //마우스 있는 곳에 타워 임시 표시해주기
            if (entity.ShowCanBuildTower())
            {
                //설치가 가능하다면 해당 위치에 설치
                entity.CreateTower();
            }
        }
    }
}