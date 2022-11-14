using Assets.Scripts.Core.Player.Bonuses.ScriptableScripts;
using UnityEngine;

namespace Assets.Scripts.Core.Player.Bonuses.Abstract
{
    public abstract class BuffEffect 
    {
        protected ScriptableDataBuff _scriptableDataBuff;
        protected GameObject _buffOwner;
        protected bool _buffIsEnded;


        public abstract void Apply();
        public abstract void Destroy();
    }
}
