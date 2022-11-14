using Assets.Scripts.Core.Player.Bonuses.Abstract;
using Assets.Scripts.Core.Player.Bonuses.ScriptableScripts;
using System;
using UnityEngine;

namespace Assets.Scripts.Core.Player.Bonuses
{
    public class HealBuff : PermanentBuff, ISupportBuff
    {
        private IHealeable _healeableObject;

        public override void Init(GameObject baffOwner)
        {
            _healeableObject = baffOwner.GetComponent<IHealeable>();
        }

        public override void Apply()
        {
            _healeableObject.Heal();
            _buffIsEnded = true;
        }

    }
}
