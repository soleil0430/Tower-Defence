using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerState;

public class Tower : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Material material;
    public BoxCollider boxCollider;
    public TowerStateMachine stateMachine;

    public bool isCanBuild = false;
    public bool isBuilded = false;

    public LayerMask attackMask;
    public float searchRadius = 5f;
    public GameObject target;
    

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        boxCollider = GetComponentInChildren<BoxCollider>();
        material = meshRenderer.material;
    }

    public void CheckCanBuild()
    {
        Vector3 center = transform.position + new Vector3(0f, boxCollider.size.y * 0.5f + 0.1f, 0f);
        Vector3 halfExtents = boxCollider.size * 0.5f;
        Collider[] colliders = Physics.OverlapBox(center, halfExtents, transform.rotation);
        //설치 가능
        isCanBuild = (colliders.Length == 1);
    }

    public void SearchEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, searchRadius, attackMask, QueryTriggerInteraction.Ignore);
        if (colliders.Length > 0)
        {
            target = colliders[0].gameObject;
        }
    }

    public void Attack()
    {
        Vector3 toTarget = target.transform.position - transform.position;
        if (toTarget.magnitude > searchRadius)
        {
            target = null;
            return;
        }
        else
        {
            transform.LookAt(target.transform.position);
        }
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }
#endif
}
