using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(CircleCollider2D))]
public class MonsterCtrl : MonoBehaviour
{
    public enum MonsterState
    {
        Idle,
        Move,
        Attack,
        Dead,
    }

    [Header("----- Scripts -----")]
    [SerializeField] PlayerCtrl _player;
    [SerializeField] MonsterData _data;
    [SerializeField] MonsterRenderer _renderer;
    [SerializeField] LevelUpStats _levelUpStats;

    [Header("----- Components -----")]
    [SerializeField] Rigidbody2D _rigid;
    [SerializeField] Xp _xpPrefab;
    [SerializeField] CircleCollider2D _collider;

    public MonsterData Data => _data;

    Vector2 _dir;
    MonsterState _state = MonsterState.Move;

    Coroutine _attackRoutine;
    Coroutine _deadCoroutine;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _renderer = GetComponentInChildren<MonsterRenderer>();
        _collider = GetComponent<CircleCollider2D>();

        _data.Init();
    }

    private void Update()
    {
        // Å×½ºÆ®
        if (Input.GetKeyDown(KeyCode.Alpha2))
            TakeDamage(2f);

        if (_state == MonsterState.Dead)
            return;

        if (_data.Hp <= 0f)
        {
            Dead();
            return;
        }

        switch (_state)
        {
            case MonsterState.Idle:
                break;

            case MonsterState.Move:
                ChasePlayer();
                break;

            case MonsterState.Attack:
                Stop();

                if (_attackRoutine == null)
                    _attackRoutine = StartCoroutine(AttackRoutine());
                break;

            case MonsterState.Dead:
                Stop();
                break;

            default:
                break;
        }
    }

    public void Initialize(PlayerCtrl player, LevelUpStats levelUpStats)
    {
        _player = player;
        _levelUpStats = levelUpStats;
    }

    void ChasePlayer()
    {
        if (_state == MonsterState.Dead)
            return;

        Vector2 playerPos = _player.transform.position;
        Vector2 monsterPos = transform.position;
        _dir = (playerPos - monsterPos).normalized;

        _rigid.velocity = _dir * _data.Speed;

        _renderer.MRMove(_dir);
    }

    void Stop()
    {
        _rigid.velocity = Vector2.zero;
    }

    public void TakeDamage(float damage)
    {
        if (_state == MonsterState.Dead)
            return;

        _renderer.MRDamage();
        _data.Damage(damage);
    }

    void CreateXp()
    {
        Xp xp = Instantiate(_xpPrefab, transform.position, Quaternion.identity);
        xp.Initialize(_player, this, _levelUpStats
            );
        xp.xpAmount = _data.Xp;
    }

    void Dead()
    {
        if (_state == MonsterState.Dead)
            return;

        Stop();

        if (_attackRoutine != null)
        {
            StopCoroutine(_attackRoutine);
            _attackRoutine = null;
        }

        _renderer.MRDead();
        CreateXp();

        if (_deadCoroutine == null)
            _deadCoroutine = StartCoroutine(DeadRoutine());

        _state = MonsterState.Dead;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
            _state = MonsterState.Attack;
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
            _state = MonsterState.Move;
    }

    IEnumerator AttackRoutine()
    {
        _player.TakeDamage(_data.Power);
        yield return new WaitForSeconds(_data.AttackCoolTIme);
    }

    IEnumerator DeadRoutine()
    {
        _rigid.simulated = false;

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
        //gameObject.SetActive(false);
        //_collider.enabled = false;
        //_deadCoroutine = null;
    }
}
