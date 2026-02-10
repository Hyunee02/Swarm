using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    [SerializeField] MonsterData _monsterData;
    [SerializeField] MonsterRenderer _renderer;
    [SerializeField] PlayerCtrl _player;

    private void Awake()
    {
        _renderer = GetComponentInChildren<MonsterRenderer>();
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

        transform.position += dir * _monsterData.Speed * Time.deltaTime;

        _renderer.MRMove(dir);
    }

    //public void TakeDamage(float damage)
    //{
    //    _monsterData.Damage(damage);
    //    _renderer.MRDamage();
    //}
}
