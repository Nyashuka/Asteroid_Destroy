using Assets.Scripts.Core.Battle.Abstract;
using Assets.Scripts.Core.Player.Bonuses.Abstract;

namespace Assets.Scripts.Core.Player.Bonuses
{
    public class ShieldBuff : TimedBuff, IDamageable
    {
        private IDamageable _oldDamageable;
        private const int DAMAGE = 0;

        public override void Activate()
        {
            _buffOwner.ChangeDamageable(this);
        }

        public void MakeDamage(int damage)
        {
            _buffOwner.MakeDamage(DAMAGE);
        }

        public void Init(Player buffOwner, IDamageable damageable)
        {
           _buffOwner = buffOwner;
           _oldDamageable = damageable;
        }

        public void SetDamageable(IDamageable damageable)
        {
            _oldDamageable = damageable;
        }

        public override void End()
        {
            _buffOwner.ChangeDamageable(_oldDamageable);
        }
    }

    
}
