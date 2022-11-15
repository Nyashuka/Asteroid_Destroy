using UnityEngine;

namespace Assets.Scripts.Core.Player.Bonuses.Abstract
{
    public abstract class TimedBuff : BuffEffect
    {
        [SerializeField] protected float _duration;

        public abstract void Activate();

        public void Tick(float delta)
        {
            _duration -= delta;
            Debug.Log(_duration);
            if (_duration <= 0)
            {
                End();
                _buffIsEnded = true;
            }
        }

        protected abstract void End();
    }
}
