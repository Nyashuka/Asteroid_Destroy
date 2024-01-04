using System;
using UnityEngine;

namespace Assets.Scripts.Core.PlayersComponents.UserInput
{
    public class AndroidUserInput : IUserInput
    {
        public event Action<Vector3> MoveEvent;
        private Camera _mainCamera;

        public AndroidUserInput()
        {
            _mainCamera = Camera.main;
        }

        public void Update()
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.touches[0];
                MoveEvent?.Invoke(_mainCamera.ScreenToWorldPoint(touch.position));
            }
        }
    }
}
