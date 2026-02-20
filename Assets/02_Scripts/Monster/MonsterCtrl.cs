using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class MonsterCtrl : MonoBehaviour
{
    [SerializeField] MonsterData _data;
    [SerializeField] MonsterRenderer _renderer;
    [SerializeField] Transform _player;

    [SerializeField] LevelManager _levelMgr;

    [SerializeField] Rigidbody2D _rigid;

    [SerializeField] GameObject _xpPrefab;

    public MonsterData Data => _data;

    private void Awake()
    {
        _renderer = GetComponentInChildren<MonsterRenderer>();
        _rigid = GetComponent<Rigidbody2D>();

        _data.Init();
    }

    private void Update()
    {
        ChasePlayer();

        if (Input.GetKeyDown(KeyCode.Space))
            Death();
    }

    //public void Initialize(MonsterRenderer renderer, PlayerCtrl player)
    //{
    //    _renderer = renderer;
    //    _player = player;
    //}

    public void ChasePlayer()
    {
        Vector3 playerPos = _player.transform.position;
        Vector3 monsterPos = transform.position;
        Vector3 dir = (playerPos - monsterPos).normalized;               
        float dist = Vector3.Distance(playerPos, monsterPos);

        if (dist > 0.8)      
            transform.Translate(dir * _data.Speed * Time.deltaTime); 

        _renderer.MRMove(dir);
    }

    public void TakeDamage(float damage)
    {
        _renderer.MRDamage();
        _data.Damage(damage);
    }

    public void Death()
    {
        _renderer.MRDeath();
        gameObject.SetActive(false);
        _levelMgr.GetXp(_data.Xp);
        Instantiate(_xpPrefab);
    }

    //private void OnTriggerEnter2D(Collider2D coll)
    //{
    //    if (coll.CompareTag("Skill"))
    //    {
    //        TakeDamage(1);
    //    }
    //}
}
