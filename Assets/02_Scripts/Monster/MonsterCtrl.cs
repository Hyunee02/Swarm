using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class MonsterCtrl : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] PlayerCtrl _player;
    [SerializeField] MonsterData _data;
    [SerializeField] MonsterRenderer _renderer;
    [SerializeField] LevelManager _levelMgr;

    [Header("----- Components -----")]
    [SerializeField] Rigidbody2D _rigid;

    [SerializeField] Xp _xpPrefab;

    public MonsterData Data => _data;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _renderer = GetComponentInChildren<MonsterRenderer>();

        _data.Init();
    }

    private void Update()
    {
        ChasePlayer();
    }

    public void ChasePlayer()
    {
        Vector3 playerPos = _player.transform.position;
        Vector3 monsterPos = transform.position;
        Vector3 dir = (playerPos - monsterPos).normalized;               
        float dist = Vector3.Distance(playerPos, monsterPos);

        if (dist > 0.8f)
            _rigid.velocity = dir * _data.Speed;

        _renderer.MRMove(dir);
    }

    public void TakeDamage(float damage)
    {
        _renderer.MRDamage();
        _data.Damage(damage);
    }

    public void Dead()
    {
        _renderer.MRDead();
        gameObject.SetActive(false);

        Xp xp = Instantiate(_xpPrefab);
        xp.Initialize(_player, this, _levelMgr);
        xp.xpAmount = _data.Xp;
    }

    private void OnColliderEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Skill"))
        {
            SkillData data = coll.GetComponent<SkillData>();
            TakeDamage(data.Power);
        }
    }
}
