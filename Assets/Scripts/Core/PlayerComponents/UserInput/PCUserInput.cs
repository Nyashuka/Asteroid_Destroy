using System;
using UnityEngine;

namespace Assets.Scripts.Core.PlayersComponents.UserInput
{
    public class PCUserInput : IUserInput
    {
        public event Action<Vector3> MoveEvent;
        private Camera _mainCamera;

        public PCUserInput()
        {
            _mainCamera = Camera.main;
        }

        public void Update()
        {
            if (Input.GetMouseButton(0))
            {
                MoveEvent?.Invoke(_mainCamera.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }
}
