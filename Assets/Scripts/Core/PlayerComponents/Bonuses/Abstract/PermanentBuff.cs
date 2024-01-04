using Assets.Scripts.Core.PlayersComponents.Bonuses.ScriptableScripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.PlayersComponents.Bonuses.Abstract;
using UnityEngine;

namespace Assets.Scripts.Core.PlayersComponents.Bonuses.Abstract
{
    public abstract class PermanentBuff : BuffEffect
    {
        public abstract void Apply();
    }
}
