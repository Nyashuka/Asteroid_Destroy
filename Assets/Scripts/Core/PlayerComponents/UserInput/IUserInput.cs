using System;

namespace Assets.Scripts.Core.PlayersComponents.UserInput
{
    public interface IUserInput
    {
        public event Action<UnityEngine.Vector3> MoveEvent;
        public void Update();
    }
}
