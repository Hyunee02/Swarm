using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

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

    Vector3 _dir;
    bool _isDamaged = false;

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
        GetDir();

        if (_dir != Vector3.zero)
            Move();
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
        _renderer.RMove(_dir);
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

        StartCoroutine(TakeDamageRoutine(power));

        if (_stats.Hp <= 0)
            Dead();
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        _isDamaged = false;
        StopCoroutine(TakeDamageRoutine(0f));
    }

    IEnumerator TakeDamageRoutine(float damage)
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
        _rigid.simulated = false;
    }
}
