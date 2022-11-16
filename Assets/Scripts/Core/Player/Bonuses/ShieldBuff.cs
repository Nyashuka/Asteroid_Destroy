using Assets.Scripts.Core.Battle.Abstract;
using Assets.Scripts.Core.Player.Bonuses.Abstract;

namespace Assets.Scripts.Core.Player.Bonuses
{
    public class ShieldBuff : TimedBuff, IDamageable
    {
        private IDamageable _oldDamageable;
        public override void Activate()
        {
            _oldDamageable = _buffOwner.Damageable;
            _buffOwner.ChangeDamageable(this);
        }

        public void MakeDamage(int damage)
        {
            _buffOwner.Health.DecreaseHealth(0);
        }

        public override void Init(Player buffOwner)
        {
           _buffOwner = buffOwner;
        }

        public override void End()
        {
            _buffOwner.ChangeDamageable(_oldDamageable);
        }
    }
}
