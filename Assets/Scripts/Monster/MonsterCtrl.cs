using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    [SerializeField] MonsterData _data;
    [SerializeField] MonsterRenderer _renderer;
    [SerializeField] Transform _player;

    public MonsterData Data => _data;

    private void Awake()
    {
        _renderer = GetComponentInChildren<MonsterRenderer>();
        _data.Init();
    }

    private void Update()
    {
        ChasePlayer();
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

        transform.position += dir * _data.Speed * Time.deltaTime;

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
    }

    //private void OnTriggerEnter2D(Collider2D coll)
    //{
    //    if (coll.CompareTag("Skill"))
    //    {
    //        TakeDamage(1);
    //    }
    //}
}
