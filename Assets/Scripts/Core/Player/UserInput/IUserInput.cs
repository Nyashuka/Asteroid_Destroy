using System;

namespace Assets.Scripts.Core.Player.UserInput
{
    public interface IUserInput
    {
        public event Action<UnityEngine.Vector3> MoveEvent;
        public void Update();
    }
}
