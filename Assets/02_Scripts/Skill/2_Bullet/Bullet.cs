using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected SkillData _data;
    protected Collider2D _collider;
    protected SpriteRenderer _renderer;

    public SkillData Data => _data;

    protected virtual void Awake()
    {
        _collider = GetComponent<CapsuleCollider2D>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Monster"))
        {
            MonsterCtrl monster = coll.GetComponent<MonsterCtrl>();
            monster.TakeDamage(_data.Power);
            Destroy(gameObject);
        }
    }
}
