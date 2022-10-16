using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private float _attackCooldown;

    [SerializeField] private BulletPoolProvider _bulletPoolProvider;

    private float _nextAttackTime = 0;


    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButton(0) && _nextAttackTime < Time.time)
        {
            _nextAttackTime = Time.time + _attackCooldown;

            _bulletPoolProvider.GetPool(BulletSide.Player).GetBullet(_bulletSpawnPosition.position).Init(_bulletPoolProvider.GetPool(BulletSide.Player));

        }
    }
}
