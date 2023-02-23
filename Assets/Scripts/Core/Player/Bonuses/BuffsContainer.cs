using Assets.Scripts.Core.Player.Bonuses.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Player.Bonuses
{
    public class BuffsContainer
    {
        private Player _player;
        private BuffIndicator _buffIndicator;
        private Dictionary<Type, TimedBuff> _buffs = new Dictionary<Type, TimedBuff>();

        public BuffsContainer(Player player, BuffIndicator buffIndicator)
        {
            _player = player;
            _buffIndicator = buffIndicator;
            _buffs = new Dictionary<Type, TimedBuff>();
        }

        public void AddBuff(BuffContainer buffContainer)
        {
            BuffEffect buff = buffContainer.GetBuff();

            buff.Init(_player);

            if (buff is PermanentBuff permanentBuff)
            {
                permanentBuff.Apply();
            }
            else if (buff is TimedBuff timedBuff)
            {
                Type buffType = timedBuff.GetType();

                if (_buffs.ContainsKey(buffType))
                {
                    _buffs[buffType].End();
                    _buffIndicator.Remove(buffType);
                    _buffs.Remove(buffType);
                }

                _buffs.Add(buffType, timedBuff);
                _buffIndicator.Add(buffType, timedBuff.IndicatorIamge);
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
