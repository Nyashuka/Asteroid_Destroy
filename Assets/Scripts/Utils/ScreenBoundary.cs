using Assets.Scripts.Services;
using Assets.Scripts.Services.ServiceLocatorSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Utils
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
            InitializeBoundary();

            _xCorrection = -0.3f;
            _zMaxCorrection = 2;
            _zMinCorrection = 0.5f;

            ServiceLocator.Instance.Register(this);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IDestroyable poolable))
                LeftWorld?.Invoke(poolable);
        }

        private void InitializeBoundary()
        {
            //zMax = _zMaxCorrection;
            //zMin = _zMinCorrection;

            float widthScreen = Screen.width;
            float heightScreen = Screen.height;

            zMax = Camera.main.orthographicSize - _zMaxCorrection;
            zMin = -Camera.main.orthographicSize + _zMinCorrection;

            if (widthScreen < heightScreen)
            {
                float x = widthScreen / heightScreen * Camera.main.orthographicSize;

                xMin = -x - _xCorrection;
                xMax = x + _xCorrection;
            }
        }
    }
}
