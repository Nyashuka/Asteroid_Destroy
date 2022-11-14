using Assets.Scripts.Core.Player.Attack;
using Assets.Scripts.Core.Player.Attack.Abstract;
using Assets.Scripts.Core.Player.Bonuses;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private Transform _parentForPoolObjects;

    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPosition;
    [SerializeField] private float _attackCooldown;
    [SerializeField] private int _countBulletsInPool;
    [SerializeField] private WorldBoundary _worldBoundary;

    private ObjectPool<Bullet> _bulletPool;

    private float _nextAttackTime = 0;

    private bool IsPaused => ServicesProvider.Instance.PauseManager.IsPaused;

    private IPlayerAttack _playerAttack;

    private void Start()
    {
        _bulletPool = new ObjectPool<Bullet>(_bulletPrefab, _countBulletsInPool, _parentForPoolObjects);
        _worldBoundary.LeftWorld += _bulletPool.ReturnObjectToPool;

        _playerAttack = new SimplePlayerAttack();

        var atk = new MultiShotBuff();
        atk.Init(this.gameObject);
        _playerAttack = atk;
    }

    private void Update()
    {
        if (IsPaused)
            return;

        if (_nextAttackTime > Time.time)
            return;

        _nextAttackTime = Time.time + _attackCooldown;

        Attack();
    }

    private void Attack()
    {
        if (Input.GetMouseButton(0) || Input.touchCount == 1)
        {
            _playerAttack.Attack(_bulletPool, _bulletSpawnPosition);
        }
    }
}
