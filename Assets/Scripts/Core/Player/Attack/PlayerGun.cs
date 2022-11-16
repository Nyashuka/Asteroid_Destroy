using Assets.Scripts.Core.Player.Attack;
using Assets.Scripts.Core.Player.Attack.Abstract;
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

    private IPlayerAttack _playerAttack;

    public IPlayerAttack PlayerAttack => _playerAttack;
    private bool IsPaused => ServicesProvider.Instance.PauseManager.IsPaused;

    private void Start()
    {
        _bulletPool = new ObjectPool<Bullet>(_bulletPrefab, _countBulletsInPool, _parentForPoolObjects);
        _worldBoundary.LeftWorld += _bulletPool.ReturnObjectToPool;

        _playerAttack = new SimplePlayerAttack();
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
            Debug.Log($"{nameof(_playerAttack)} is null: {_playerAttack == null}, {nameof(_bulletSpawnPosition)} is null {_bulletSpawnPosition == null}");
            _playerAttack.Attack(_bulletPool, _bulletSpawnPosition.position);
        }
    }

    public void ChangeAttackImplementation(IPlayerAttack attackImplementation)
    {
        _playerAttack = attackImplementation;
    }
}
