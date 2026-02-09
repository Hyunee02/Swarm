using System.Collections;
using System.Threading;
using UnityEngine;

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
    Rigidbody2D _rigid;

    Vector3 _dir;
    PlayerState _state = PlayerState.Idle;
    GameObject _area;

    [SerializeField] float _dashCoolTime;
    [SerializeField] float _dashTime;
    float _timer;

    public void Initialize(PlayerStats stats, PlayerRenderer renderer)
    {
        _stats = stats;
        _renderer = renderer;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

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

        if (_dir == Vector3.zero)
            _state = PlayerState.Idle;

        transform.position += _dir * _stats.Speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
            _state = PlayerState.Dash;
    }
    #endregion

    #region 대시

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GetDir();

            // 스피드 업
            float _dashSpeed = _stats.Speed * 3;

            float timer = 0;
            timer += Time.deltaTime;

            if (timer > _dashCoolTime)
            {
                _rigid.AddForce(_dir * _dashSpeed * Time.deltaTime);
                timer = 0;
            }

            _state = PlayerState.Idle;
        }
    }
    #endregion

    #region 피격
    public void Damage(float damage)
    {
        if (_stats.Hp < 0)
            _state = PlayerState.Death;

        _stats.GetDamage(damage);
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Monster"))
        {
            
        }
    }


    #endregion
}
