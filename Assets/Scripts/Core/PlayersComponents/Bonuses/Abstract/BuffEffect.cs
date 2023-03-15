using UnityEngine;

namespace Assets.Scripts.Core.PlayersComponents.Bonuses.Abstract
{
    public abstract class BuffEffect 
    {
        protected Player _buffOwner;
        protected bool _buffIsEnded;
        public bool IsFinished => _buffIsEnded;

    }
}
