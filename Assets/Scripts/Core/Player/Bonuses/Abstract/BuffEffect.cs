using Assets.Scripts.Core.Player.Bonuses.ScriptableScripts;
using UnityEngine;

namespace Assets.Scripts.Core.Player.Bonuses.Abstract
{
    public abstract class BuffEffect 
    {
        protected GameObject _buffOwner;
        protected bool _buffIsEnded;

        public abstract void Init(GameObject baffOwner);

        public abstract void Apply();

     
    }
}
