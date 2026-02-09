using System.Collections;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Move,
        Dash,
    }

    PlayerStats _stats;
    PlayerRenderer _renderer;

    Vector3 _dir;
    PlayerState _state;

    bool IsMove;

    [SerializeField] float _dash;
    [SerializeField] float _dashCoolTime;

    public void Initialize(PlayerStats stats, PlayerRenderer renderer)
    {
        _stats = stats;
        _renderer = renderer;
    }

    private void Update()
    {
        switch (_state)
        {
            case PlayerState.Idle:
                break;

            case PlayerState.Move:
                Move();
                break;

            case PlayerState.Dash:
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
        if (_dir == Vector3.zero)
            _state = PlayerState.Idle;

        GetDir();

        if (IsMove)
        {
            transform.position += _dir * _stats.Speed * Time.deltaTime;
            _renderer.RMove(_dir);
        }
        else
            IsMove = false;
    }
    #endregion

    #region 대쉬

    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(DashRoutine());
        }
    }

    IEnumerator DashRoutine()
    {
        GetDir();
        float _dashSpeed = _stats.Speed * 3;

        transform.position += _dir * _dashSpeed * Time.deltaTime;

        _renderer.RDash(_dir);

        yield return new WaitForSeconds(_dashCoolTime);
    }
    #endregion
}
