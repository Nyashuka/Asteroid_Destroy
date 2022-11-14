using Assets.Scripts.Core.Player.Attack.Abstract;
using Assets.Scripts.Core.Player.Bonuses.Abstract;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core.Player.Bonuses
{
    public class TrippleShotBuff : TimedBuff, IPlayerAttack
    {
        private int _countShots = 0;
        private int _skippBullet = 0;
        private const float _distancebetweenBullets = 0.3f;

        public override void Apply()
        {
            throw new System.NotImplementedException();
        }

        public void Attack(ObjectPool<Bullet> pool, Transform basePosition)
        {
            if(_countShots % 2 == 0)
            {

            }
            else
            {
                SpawnOddCountBullets(pool, basePosition.position);
            }
            

        }

        private void SpawnEvenCountBullets(ObjectPool<Bullet> pool, Vector3 basePosition)
        {

        }

        private void SpawnOddCountBullets(ObjectPool<Bullet> pool, Vector3 basePosition)
        {
            Bullet bullet;
            Vector3 newPosition = basePosition;

            for (int i = 1; i <= _countShots; i++)
            {
                if(i <= _skippBullet)
                {
                    newPosition = new Vector3(((i - 1) * _distancebetweenBullets / 2) + basePosition.x,
                                                                        basePosition.y, basePosition.z);
                }
                else
                {
                    newPosition = new Vector3(((i - 1) * 0.3f / 2 * (-1) + _distancebetweenBullets) + basePosition.x,
                                                                        basePosition.y, basePosition.z);
                }

                bullet = (Bullet)pool.GetObject(newPosition);


                bullet.Hit += pool.ReturnObjectToPool;
            }
        }

        public override void Init(GameObject baffOwner)
        {
            _countShots = 5;
            _skippBullet = (_countShots - 1) / 2 + 1;
        }
    }
}
