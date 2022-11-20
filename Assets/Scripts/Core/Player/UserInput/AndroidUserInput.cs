using System;
using UnityEngine;

namespace Assets.Scripts.Core.Player.UserInput
{
    public class AndroidUserInput : IUserInput
    {
        public event Action<Vector3> MoveEvent;

        public void Update()
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.touches[0];
                MoveEvent?.Invoke(Camera.main.ScreenToWorldPoint(touch.position));
            }
        }
    }
}
