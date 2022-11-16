using Assets.Scripts.Core.Battle.Abstract;
using Assets.Scripts.Core.Player.Bonuses;
using Assets.Scripts.Core.Player.Bonuses.Abstract;
using BetterAttributes.Runtime.Attributes.Select;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Core.Player
{
    public class Player : MonoBehaviour, IHealeable, IDamageable
    {
        [SelectImplementation][SerializeReference] private IDamageable _damageable = new SimpleDamageable();

        [SerializeField] private Health _health;
        [SerializeField] private PlayerGun _playerGun;
        [SerializeField] private GameObject _deathVFX;
        [SerializeField] private BuffIndicator _buffIndicator;

        // private List<TimedBuff> _buffs = new List<TimedBuff>();
        private Dictionary<Type,TimedBuff> _buffs = new Dictionary<Type,TimedBuff>();

        public Health Health => _health;
        public PlayerGun PlayerGun => _playerGun;
        private bool IsPaused => ServicesProvider.Instance.PauseManager.IsPaused;
        public IDamageable Damageable => _damageable;

        public event Action DeathEvent;

        private void Start()
        {
            _health.Death += OnDeath;
        }

        private void Update()
        {
            if (IsPaused)
                return;

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

        public void MakeDamage(int damage)
        {
            _damageable.MakeDamage(damage);
        }

        private void OnDeath()
        {
            Destroy(Instantiate(_deathVFX, transform.position, transform.rotation), 1f);
            AnnounceDeath();
        }

        public void Heal()
        {
            _health.IncreaseHealth();
        }

        private void AnnounceDeath()
        {
            DeathEvent?.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            // other.TryGetValue<IPermanentBuff>(out var permanent)
            // other.TryGetValue<ITimedBuff>(out var timed)

            if (other.TryGetComponent(out BuffContainer buffContainer))
            {
                BuffEffect buff = buffContainer.GetBuff();

                buff.Init(this);

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
        }

        public void ChangeDamageable(IDamageable damageable)
        {
            _damageable = damageable;
        }
    }
}


