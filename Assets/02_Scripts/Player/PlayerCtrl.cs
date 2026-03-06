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
    [SerializeField] CapsuleCollider2D _collider;

    [SerializeField] float _limitX;
    [SerializeField] float _limitY;

    Vector2 _dir;

    bool _isMove = false;
    bool _isDead = false;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();

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

        Move();

        if (_dir == Vector2.zero)
            _renderer.RIdle(_dir);
    }


    void GetDir()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        _dir = new Vector3(h, v).normalized;
    }

    void Move()
    {
        GetDir();
        _renderer.RMove(_dir);
        _rigid.velocity = _dir * _statCal.Speed;
    }

    public void TakeDamage(float damage)
    {
        if (_isDead)
            return;

        _stats.Hp -= damage;
        _renderer.RDamage();

        if (_stats.Hp <= 0)
        {
            _isDead = true;
            Dead();
        }
    }

    void Dead()
    {
        _renderer.RDead();

        _collider.enabled = false;
        _rigid.simulated = false;
    }
}
