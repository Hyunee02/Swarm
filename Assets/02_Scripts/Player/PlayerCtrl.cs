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
    Rigidbody2D _rigid;

    public enum PlayerState
    {
        Idle,
        Move,
        Dead,
    }

    Vector3 _dir;
    bool _isDamaged = false;

    PlayerState _state = PlayerState.Idle;

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
        switch (_state)
        {
            case PlayerState.Idle:
                GetDir();
                _renderer.RIdle(_dir);

                if (_dir != Vector3.zero)
                    _state = PlayerState.Move;
                break;

            case PlayerState.Move:
                Move();
                _renderer.RMove(_dir);
                break;

            case PlayerState.Dead:
                Dead();
                _renderer.RDead();
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// Dir값 가져오기
    /// </summary>
    public void GetDir()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 _dir = new Vector3(h, v).normalized;
    }

    #region 플레이어 이동
    public void Move()
    {
        GetDir();

        _rigid.velocity = _dir * _statCal.Speed;

        //LimitPlayer();
    }

    //public void LimitPlayer()
    //{
    //    Vector3 playerPos = transform.position;

    //    if (playerPos.x > _maxX)
    //        playerPos.x = _maxX;
    //    else if (playerPos.x < -_maxX)
    //        playerPos.x = -_maxX;

    //    if (playerPos.y > _maxY)
    //        playerPos.y = _maxY;
    //    else if (playerPos.y < -_maxY)
    //        playerPos.y = -_maxY;

    //    transform.position = playerPos;
    //}
    #endregion

    #region 피격
    private void OnCollisionEnter2D(Collision2D coll)
    {
        MonsterCtrl monster = coll.gameObject.GetComponent<MonsterCtrl>();
        float power = monster.Data.Power;

        if (_stats.Hp <= 0)
            _state = PlayerState.Dead;

        StartCoroutine(TakeDamage(power));
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        _isDamaged = false;
        StopCoroutine(TakeDamage(0f));
    }

    IEnumerator TakeDamage(float damage)
    {
        _isDamaged = true;

        _stats.Damage(damage);
        _renderer.RDamage();

        yield return new WaitForSeconds(1f);
    }
    #endregion

    public void Dead()
    {
        CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();

        collider.enabled = false;
    }
}
