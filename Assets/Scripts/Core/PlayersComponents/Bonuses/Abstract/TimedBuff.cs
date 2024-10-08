﻿using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Core.PlayersComponents.Bonuses.Abstract
{
    public abstract class TimedBuff : BuffEffect
    {
        [SerializeField] protected float _duration;
        [SerializeField] Image _indicatorIamge;
        
        public Image IndicatorImage => _indicatorIamge;


        public abstract void Activate();

        public void Tick(float delta)
        {
            _duration -= delta;
            if (_duration <= 0)
            {
                End();
                _buffIsEnded = true;
            }
        }

        public abstract void End();
    }
}
