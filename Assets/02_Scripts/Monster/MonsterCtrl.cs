using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class MonsterCtrl : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] MonsterData _data;
    [SerializeField] MonsterRenderer _renderer;
    [SerializeField] LevelManager _levelMgr;

    [Header("----- Components -----")]
    [SerializeField] Transform _player;
    [SerializeField] Rigidbody2D _rigid;

    [SerializeField] GameObject _xpPrefab;

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

        if (Input.GetKeyDown(KeyCode.Space))
            Death();
    }

    public void ChasePlayer()
    {
        Vector3 playerPos = _player.transform.position;
        Vector3 monsterPos = transform.position;
        Vector3 dir = (playerPos - monsterPos).normalized;               
        float dist = Vector3.Distance(playerPos, monsterPos);

        if (dist > 0.8f)      
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

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Skill"))
        {
            SkillData data = coll.GetComponent<SkillData>();
        }
    }
}
