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
            //���콺 �ִ� ���� Ÿ�� �ӽ� ǥ�����ֱ�
            if (entity.ShowCanBuildTower())
            {
                //��ġ�� �����ϴٸ� �ش� ��ġ�� ��ġ
                entity.CreateTower();
            }
        }
    }
}