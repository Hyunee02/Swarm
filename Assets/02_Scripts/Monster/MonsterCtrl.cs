using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
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
    [SerializeField] LevelManager _levelMgr;

    [Header("----- Components -----")]
    [SerializeField] Rigidbody2D _rigid;
    [SerializeField] Xp _xpPrefab;
    [SerializeField] CircleCollider2D _collider;

    [SerializeField] float _attackCooltime;

    public MonsterData Data => _data;

    Vector2 _dir;
    MonsterState _state = MonsterState.Move;

    Coroutine _attackRoutine;
    Coroutine _deadCoroutine;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _renderer = GetComponentInChildren<MonsterRenderer>();

        _data.Init();
    }

    private void Update()
    {
        switch (_state)
        {
            case MonsterState.Idle:
                break;

            case MonsterState.Move:
                ChasePlayer();

                if (_data.Hp <= 0f)
                    Dead();
                break;

            case MonsterState.Attack:
                Stop();

                if (_attackRoutine != null)
                {
                    StopCoroutine(_attackRoutine);
                    _attackRoutine = null;
                }

                _attackRoutine = StartCoroutine(AttackRoutine());
                break;

            case MonsterState.Dead:
                break;

            default:
                break;
        }
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
        xp.Initialize(_player, this, _levelMgr);
        xp.xpAmount = _data.Xp;
    }

    void Dead()
    {
        if (_state == MonsterState.Dead)
            return;

        Stop();

        _renderer.MRDead();
        CreateXp();

        if (_deadCoroutine == null)
            _deadCoroutine = StartCoroutine(DeadRoutine());
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
            _state = MonsterState.Attack;
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        _state = MonsterState.Move;
    }

    IEnumerator AttackRoutine()
    {
        _player.TakeDamage(_data.Power);

        yield return new WaitForSeconds(_attackCooltime);

        _attackRoutine = null;
    }

    IEnumerator DeadRoutine()
    {
        _rigid.simulated = false;

        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
        _deadCoroutine = null;
    }

    // 스킬 데미지
    //private void OnTriggerEnter2D(Collider2D coll)
    //{
    //    if (_state == MonsterState.Dead)
    //        return;
    //    _state = MonsterState.Dead;

    //    if (coll.CompareTag("Skill"))
    //    {
    //        MonsterCtrl monster = coll.GetComponent<MonsterCtrl>();
    //        monster.TakeDamage(_data.Power);
    //    }
    //}
}
