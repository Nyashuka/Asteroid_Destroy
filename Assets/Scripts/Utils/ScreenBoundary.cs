using System;
using Assets.Scripts.Services;
using Core.Services.ServiceLocatorSystem;
using UnityEngine;

namespace Utils
{
    [RequireComponent(typeof(BoxCollider))]
    public class ScreenBoundary : MonoBehaviour, IService
    {
        public float xMin { get; private set; }
        public float xMax { get; private set; }
        public float zMin { get; private set; }
        public float zMax { get; private set; }

        private float _xCorrection; //  -0.3
        private float _zMaxCorrection; //  2
        private float _zMinCorrection; // 0.5

        public event Action<IDestroyable> LeftWorld;

        public void Awake()
        {
            InitializeBoundary(Camera.main);

            _xCorrection = -0.3f;
            _zMaxCorrection = 2;
            _zMinCorrection = 0.5f;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IDestroyable poolable))
                LeftWorld?.Invoke(poolable);
        }

        private void InitializeBoundary(Camera camera)
        {
            float widthScreen = Screen.width;
            float heightScreen = Screen.height;

            zMax = camera.orthographicSize - _zMaxCorrection;
            zMin = -camera.orthographicSize + _zMinCorrection;
            
            if (widthScreen < heightScreen)
            {
                float x = widthScreen / heightScreen * camera.orthographicSize;

                xMin = -x - _xCorrection;
                xMax = x + _xCorrection;
            }
        }
    }
}
