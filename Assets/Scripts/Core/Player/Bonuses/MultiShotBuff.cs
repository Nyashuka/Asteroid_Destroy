using Assets.Scripts.Core.Player.Attack.Abstract;
using Assets.Scripts.Core.Player.Bonuses.Abstract;
using UnityEngine;

namespace Assets.Scripts.Core.Player.Bonuses
{
    public class MultiShotBuff : TimedBuff, IPlayerAttack
    {
        [SerializeField] private float _distanceBetweenBullets = 0.3f;
        [SerializeField] private int _countShots;

        private int _skippBullet = 0;
        private IPlayerAttack _oldAttack;
        
        public void Attack(ObjectPool<Bullet> pool, Vector3 basePosition)
        {
            Bullet bullet;
            Vector3 newPosition;

            if (_countShots % 2 == 0)
                newPosition = new Vector3((basePosition.x + _countShots / 2 * _distanceBetweenBullets) - _distanceBetweenBullets / 2,
                                              basePosition.y, basePosition.z);
            else
                newPosition = new Vector3((basePosition.x + _skippBullet * _distanceBetweenBullets) - _distanceBetweenBullets,
                                              basePosition.y, basePosition.z);
            // 0 + 2 * 0.3 = 0.6
            // 0.6 - 0.3 / 2 = 0.45

            for (int i = 1; i <= _countShots; i++)
            {
                bullet = (Bullet)pool.GetObject(newPosition);

                newPosition = new Vector3(newPosition.x - _distanceBetweenBullets,
                                          basePosition.y, basePosition.z);

                bullet.Hit += pool.ReturnObjectToPool;
            }
        }

        public void Init(Player buffOwner, IPlayerAttack playerAttack)
        {
            _oldAttack = playerAttack;
            _skippBullet = (_countShots - 1) / 2 + 1;
            _buffOwner = buffOwner;        
        }

        public override void Activate()
        {
            _buffOwner.ChangeAttackImplementation(this);
        }

        public override void End()
        {
            _buffOwner.ChangeAttackImplementation(_oldAttack);
        }
    }
}
