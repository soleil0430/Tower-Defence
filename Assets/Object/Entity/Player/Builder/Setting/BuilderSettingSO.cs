using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BuilderSetting {
    [Serializable]
    public struct CameraMove
    {
        public float walkSpeed;
        public float runSpeed;

        public float colliderRadius;
        public LayerMask collideMask;
    }

    [Serializable]
    public struct CameraRotate
    {
        public float camRotateSpeedX;
        public float camRotateSpeedY;

        public bool camRotateInvertX;
        public bool camRotateInvertY;

        public float camRotateMin;
        public float camRotateMax;
    }

    [Serializable]
    public struct BuildTower
    {
        public LayerMask buildMask;
        public float rotateSpeed;
        public bool rotateInvert;
    }

    [CreateAssetMenu(fileName = "BuilderSettingSO", menuName = "SO/Setting/Builder")]
    public class BuilderSettingSO : ScriptableObject
    {
        public CameraMove cameraMove;
        public CameraRotate cameraRotate;
        public BuildTower buildConfig;

    }
}