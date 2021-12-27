using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using BuilderState;
using BuilderSetting;

public class Builder : MonoBehaviour
{
    public Transform cmPlayer;
    public BuilderStateMachine stateMachine;
    public BuilderSettingSO builderSettingSO;

    [DisableField] public float camMoveSpeed;

    [DisableField] public float camRotateX;
    [DisableField] public float camRotateY;

    [DisableField] public Vector3 moveDirection;
    [DisableField] public Quaternion cameraRotation;

    [DisableField] public Tower selectTower;
    [DisableField] public Tower newTower;

    [DisableField] public Vector3 buildRotation;
    [DisableField] public bool cancelBuildMode;

    public void InputMoveDirection()
    {
        moveDirection.x = (Input.GetKey(KeyCode.A) ? -1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0);
        moveDirection.y = (Input.GetKey(KeyCode.Q) ? -1 : 0) + (Input.GetKey(KeyCode.E) ? 1 : 0);
        moveDirection.z = (Input.GetKey(KeyCode.S) ? -1 : 0) + (Input.GetKey(KeyCode.W) ? 1 : 0);
        moveDirection.Normalize();
    }

    public void InputMoveSpeed()
    {
        var setting = builderSettingSO.cameraMove;
        camMoveSpeed = Input.GetKey(KeyCode.LeftShift) ? setting.runSpeed : setting.walkSpeed;
    }

    public void InputCameraRotation()
    {
        Vector3 rotation = cmPlayer.rotation.eulerAngles;

        var setting = builderSettingSO.cameraRotate;
        float speedX = setting.camRotateSpeedX;
        float speedY = setting.camRotateSpeedY;

        bool invertX = setting.camRotateInvertX;
        bool invertY = setting.camRotateInvertY;

        float minX = setting.camRotateMin;
        float maxX = setting.camRotateMax;

        camRotateX += Input.GetAxis("Mouse Y") * speedX * (invertX ? 1 : -1);
        camRotateX = Mathf.Clamp(camRotateX, minX, maxX);

        rotation.x = camRotateX;

        camRotateY += Input.GetAxis("Mouse X") * speedY * (invertY ? 1 : -1);
        camRotateY = Mathf.Repeat(camRotateY, 360);

        rotation.y = camRotateY;

        cameraRotation = Quaternion.Euler(rotation);
    }

    public void Move()
    {
        var setting = builderSettingSO.cameraMove;
        Vector3 velocity = moveDirection * camMoveSpeed * Time.deltaTime;
        velocity = cmPlayer.TransformVector(velocity);

        if (!Physics.CheckSphere(cmPlayer.position + velocity, setting.colliderRadius, setting.collideMask, QueryTriggerInteraction.Ignore))
        {
            cmPlayer.position += velocity;
        }
    }

    public void Rotate()
    {
        cmPlayer.rotation = cameraRotation;
    }

    public void CreateTowerGizmo()
    {
        newTower = Instantiate(selectTower);
    }

    public bool ShowCanBuildTower()
    {
        var setting = builderSettingSO.buildConfig;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, setting.buildMask, QueryTriggerInteraction.Ignore))
        {
            Vector3 targetPosition = hit.point;
            buildRotation.y += Input.GetAxis("Mouse ScrollWheel") * setting.rotateSpeed * (setting.rotateInvert ? 1 : -1);

            newTower.transform.position = targetPosition;
            newTower.transform.rotation = Quaternion.Euler(buildRotation);

            return newTower.isCanBuild;
        }

        return false;
    }

    public void CreateTower()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) &&
            !EventSystem.current.IsPointerOverGameObject())
        {
            newTower.isBuilded = true;
            CancelBuildMode();
        }
    }

    public void SelectTower(Tower selected)
    {
        selectTower = selected;
    }

    public void CancelBuildMode()
    {
        cancelBuildMode = true;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(cmPlayer.position, builderSettingSO.cameraMove.colliderRadius);
    }
#endif
}
