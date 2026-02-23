using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerCtrl : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] PlayerRenderer _renderer;
    [SerializeField] StatCalculator _statCal;
    [SerializeField] AreaCtrl _area;

    [Header("----- Components -----")]
    Rigidbody2D _rigid;

    public enum PlayerState
    {
        Idle,
        Move,
        Death,
    }

    Vector3 _dir;

    PlayerState _state = PlayerState.Idle;

    [SerializeField] float _maxX;
    [SerializeField] float _maxY;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();

        _statCal.Init();
    }

    private void Start()
    {
        _area.Init();
    }

    //public void Initialize(PlayerStats stats, PlayerRenderer renderer)
    //{
    //    _stats = stats;
    //    _renderer = renderer;

    //    _area.Init();
    //}

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

            case PlayerState.Death:
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

    public void LimitPlayer()
    {
        Vector3 playerPos = transform.position;

        if (playerPos.x > _maxX)
            playerPos.x = _maxX;
        else if (playerPos.x < -_maxX)
            playerPos.x = -_maxX;

        if (playerPos.y > _maxY)
            playerPos.y = _maxY;
        else if (playerPos.y < -_maxY)
            playerPos.y = -_maxY;

        transform.position = playerPos;
    }
    #endregion

    #region 피격
    //public void TakeDamage(float damage)
    //{
    //    if (_stats.Hp < 0)
    //        _state = PlayerState.Death;

    //    _stats.GetDamage(damage);
    //}

    //private void OnTriggerEnter2D(Collider2D coll)
    //{
    //    if (coll.CompareTag("Monster"))
    //    {
    //        MonsterCtrl monster = coll.GetComponent<MonsterCtrl>();
    //        MonsterData data = monster.Data;

    //        TakeDamage(data.Power);

    //        if (data.Hp <= 0)
    //        {
    //            monster.Death();
    //        }
    //    }
    //}

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Monster"))
        {

        }
    }
    #endregion

    public void Die()
    {

    }
}
