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

    public MonsterData Data => _data;

    MonsterState _state = MonsterState.Move;

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

            case MonsterState.Dead:
                break;

            default:
                break;
        }
    }

    public void ChasePlayer()
    {
        if (_state == MonsterState.Dead)
            return;

        Vector3 playerPos = _player.transform.position;
        Vector3 monsterPos = transform.position;
        Vector3 dir = (playerPos - monsterPos).normalized;               
        float dist = Vector3.Distance(playerPos, monsterPos);

        if (dist > 0.8f)
            _rigid.velocity = dir * _data.Speed;
        else
            _rigid.velocity = Vector2.zero;

        _renderer.MRMove(dir);
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

    public void Dead()
    {
        if (_state == MonsterState.Dead)
            return;

        _renderer.MRDead();
        CreateXp();

        if (_deadCoroutine == null)
            _deadCoroutine = StartCoroutine(DeadRoutine());
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (_state == MonsterState.Dead)
            return;
        _state = MonsterState.Dead;

        if (coll.CompareTag("Skill"))
        {
            SkillData data = coll.GetComponent<SkillData>();
            TakeDamage(data.Power);
        }
    }

    IEnumerator DeadRoutine()
    {
        _rigid.velocity = Vector2.zero;
        _rigid.simulated = false;

        yield return new WaitForSeconds(2f);

        gameObject.SetActive(false);
        _deadCoroutine = null;
    }
}
