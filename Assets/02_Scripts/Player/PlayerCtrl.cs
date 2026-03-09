using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(CapsuleCollider2D))]
public class PlayerCtrl : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] PlayerRenderer _renderer;
    [SerializeField] PlayerStats _stats;
    [SerializeField] StatCalculator _statCal;
    [SerializeField] AreaCtrl _area;

    [Header("----- Components -----")]
    Rigidbody2D _rigid;
    CapsuleCollider2D _collider;

    [SerializeField] Vector2 _limit;

    Vector2 _dir;

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
        //LimitPlayerPos();
    }

    void GetDir()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        _dir = new Vector2(h, v).normalized;
    }

    void Move()
    {
        GetDir();
        _rigid.velocity = _dir * _statCal.Speed;
        _renderer.RMove(_rigid.velocity);
    }

    //void LimitPlayerPos()
    //{
    //    Vector2 playerPos = transform.position;
    //    playerPos.x = Mathf.Clamp(playerPos.x, -_limit.x, _limit.x);
    //    playerPos.y = Mathf.Clamp(playerPos.y, -_limit.y, _limit.y);

    //    transform.position = playerPos;
    //}

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
