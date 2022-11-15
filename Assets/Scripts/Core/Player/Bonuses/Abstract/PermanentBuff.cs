using Assets.Scripts.Core.Player.Bonuses.ScriptableScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Player.Bonuses.Abstract
{
    public abstract class PermanentBuff : BuffEffect
    {
        public abstract void Apply();
    }
}
