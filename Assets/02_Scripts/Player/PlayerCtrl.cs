using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerCtrl : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Move,
        Dash,
        Death,
    }

    PlayerStats _stats;
    PlayerRenderer _renderer;

    Vector3 _dir;
    Rigidbody2D _rigid;

    PlayerState _state = PlayerState.Idle;
    [SerializeField] GameObject _area;

    [SerializeField] float _maxX;
    [SerializeField] float _maxY;

    [SerializeField] float _dashTimer;
    [SerializeField] float _dashTime;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    public void Initialize(PlayerStats stats, PlayerRenderer renderer)
    {
        _stats = stats;
        _renderer = renderer;

        _stats.Init(_area);
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

                if (Input.GetKeyDown(KeyCode.LeftShift))
                    StartDash();
                break;

            case PlayerState.Move:
                Move();
                _renderer.RMove(_dir);

                if (Input.GetKeyDown(KeyCode.LeftShift))
                    StartDash();
                break;

            case PlayerState.Dash:
                Dash();
                _renderer.RDash(_dir);
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

        _dir = new Vector3(h, v).normalized;
    }

    #region 플레이어 이동
    public void Move()
    {
        GetDir();

        _rigid.velocity = _dir * _stats.Speed;

        //if (_dir == Vector3.zero)
        //    _state = PlayerState.Idle;

        //transform.position += _dir * _stats.Speed * Time.deltaTime;

        LimitPlayer();
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

    #region 대시
    public void StartDash()
    {
        _dashTimer = _dashTime;

        _state = PlayerState.Dash;
    }

    public void  Dash()
    {
        _dashTime -= Time.deltaTime;

        if (_dashTimer < 0)
            _state = PlayerState.Idle;
    }
    #endregion

    #region 피격
    public void TakeDamage(float damage)
    {
        if (_stats.Hp < 0)
            _state = PlayerState.Death;

        _stats.GetDamage(damage);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Monster"))
        {
            MonsterCtrl monster = coll.GetComponent<MonsterCtrl>();
            MonsterData data = monster.Data;

            TakeDamage(data.Power);

            if (data.Hp <= 0)
            {
                monster.Death();
            }
        }
    }

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
