using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerCtrl : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] PlayerRenderer _renderer;
    [SerializeField] PlayerStats _stats;
    [SerializeField] StatCalculator _statCal;
    [SerializeField] AreaCtrl _area;

    [Header("----- Components -----")]
    [SerializeField] Rigidbody2D _rigid;

    [SerializeField] float _limitX;
    [SerializeField] float _limitY;

    Vector3 _dir;
    Coroutine _damageRoutine;

    bool _isDamaged = false;
    bool _isDead = false;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();

        _statCal.Init();
    }

    private void Start()
    {
        _area.Init();
    }

    private void Update()
    {
        if (_isDead)
            return;

        GetDir();
        Move();
    }

    public void GetDir()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        _dir = new Vector3(h, v).normalized;
    }

    #region 플레이어 이동
    public void Move()
    {
        _renderer.RMove(_dir);

        if (_dir == Vector3.zero)
        {
            _rigid.velocity = Vector2.zero;
            return;
        }

        _rigid.velocity = _dir * _statCal.Speed;

        //LimitPlayer();
    }

    public void LimitPlayer()
    {
        Vector2 playerPos = transform.position;

        if (playerPos.x > _limitX)
            playerPos.x = _limitX;
        else if (playerPos.x < -_limitX)
            playerPos.x = -_limitX;

        if (playerPos.y > _limitY)
            playerPos.y = _limitY;
        else if (playerPos.y < -_limitY)
            playerPos.y = -_limitY;

        transform.position = playerPos;
    }
    #endregion

    #region 피격
    private void OnCollisionEnter2D(Collision2D coll)
    {
        MonsterCtrl monster = coll.gameObject.GetComponent<MonsterCtrl>();
        float power = monster.Data.Power;
        float speed = monster.Data.Speed;
        monster.Data.SetSpeedZero();

        if (_damageRoutine == null)
            _damageRoutine = StartCoroutine(TakeDamageRoutine(power));
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        MonsterCtrl monster = coll.gameObject.GetComponent<MonsterCtrl>();
        float speed = monster.Data.Speed;
        monster.Data.SetSpeedOrigin();

        _isDamaged = false;

        if (_damageRoutine != null)
        {
            StopCoroutine(_damageRoutine);
            _damageRoutine = null;
        }
    }

    IEnumerator TakeDamageRoutine(float damage)
    {
        _isDamaged = true;

        while (_isDamaged)
        {
            _stats.Damage(damage);
            _renderer.RDamage();

            if (_stats.Hp <= 0)
            {
                _isDamaged = false;
                Dead();
                yield break;
            }

            yield return new WaitForSeconds(1f);
        }
    }
    #endregion

    public void Dead()
    {
        if (_isDead)
            return;
        _isDead = true;

        _rigid.velocity = Vector2.zero;
        _renderer.RDead();

        CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
        collider.enabled = false;
        _rigid.simulated = false;
    }
}
