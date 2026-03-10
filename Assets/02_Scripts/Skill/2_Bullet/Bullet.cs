using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected SkillData _data;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Monster"))
        {
            MonsterCtrl monster = coll.gameObject.GetComponent<MonsterCtrl>();
            monster.TakeDamage(_data.Power);
        }
    }
}
