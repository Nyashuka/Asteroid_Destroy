using Assets.Scripts.Core.Player.Bonuses.Abstract;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Player.Bonuses
{

    public class BuffsContainer
    {
        private Player _player;
        private BuffIndicator _buffIndicator;
        private Dictionary<Type, TimedBuff> _buffs = new Dictionary<Type, TimedBuff>();

        private delegate void InitDelegate(BuffEffect permanentBuff);

        private Dictionary<Type, InitDelegate> _permanentInits;
        private Dictionary<Type, InitDelegate> _timedInits;

        public BuffsContainer(Player player, BuffIndicator buffIndicator)
        {
            _player = player;
            _buffIndicator = buffIndicator;
            _buffs = new Dictionary<Type, TimedBuff>();


            _permanentInits = new Dictionary<Type, InitDelegate>
            {
                { typeof(HealBuff), (buff) => _player.SetBuff((HealBuff)buff) }
            };

            _timedInits = new Dictionary<Type, InitDelegate>
            {
                { typeof(ShieldBuff), (buff) => _player.SetBuff((ShieldBuff)buff) },
                { typeof(MultiShotBuff), (buff) => _player.SetBuff((MultiShotBuff)buff) },
            };
        }

        public void AddBuff(BuffContainer buffContainer)
        {
            BuffEffect buff = buffContainer.GetBuff();

            Type buffType = buff.GetType();

            if (buff is PermanentBuff permanentBuff)
            {
                _permanentInits[buffType].Invoke(permanentBuff);
                permanentBuff.Apply();
                return;
            }

            if(buff is TimedBuff timedBuff)
            {
                if (_buffs.ContainsKey(buffType))
                {
                    _buffs[buffType].End();
                    _buffIndicator.Remove(buffType);
                    _buffs.Remove(buffType);
                }

                _timedInits[buffType].Invoke(timedBuff);

                _buffs.Add(buffType, timedBuff);
                _buffIndicator.Add(buffType, timedBuff.IndicatorImage);
                timedBuff.Activate();
            }
        }

        public void UseBuffs()
        {
            foreach (var buff in new List<TimedBuff>(_buffs.Values))
            {
                buff.Tick(Time.deltaTime);
                if (buff.IsFinished)
                {
                    _buffIndicator.Remove(buff.GetType());
                    _buffs.Remove(buff.GetType());
                }
            }
        }
    }
}
