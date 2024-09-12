﻿using Assets.Scripts.Core.PlayersComponents;
using Core.PlayerComponents;

namespace Core.PlayersComponents.Bonuses.Abstract
{
    public abstract class BuffEffect 
    {
        protected Player _buffOwner;
        protected bool _buffIsEnded;
        public bool IsFinished => _buffIsEnded;

    }
}