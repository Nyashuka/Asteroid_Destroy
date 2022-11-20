using System;
using UnityEngine;

namespace Assets.Scripts.Core.Player.UserInput
{
    public class PCUserInput : IUserInput
    {
        public event Action<Vector3> MoveEvent;

        public void Update()
        {
            if (Input.GetMouseButton(0))
            {
                MoveEvent?.Invoke(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }
}
