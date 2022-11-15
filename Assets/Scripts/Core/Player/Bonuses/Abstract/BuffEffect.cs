using UnityEngine;

namespace Assets.Scripts.Core.Player.Bonuses.Abstract
{
    public abstract class BuffEffect 
    {
        protected Player _buffOwner;
        protected bool _buffIsEnded;
        public bool IsFinished => _buffIsEnded;

        public abstract void Init(Player baffOwner);
    }
}
