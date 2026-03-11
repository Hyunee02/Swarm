using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] SkillData _data;
    [SerializeField] Transform _player;

    [SerializeField] float _radius;
    [SerializeField] MonsterCtrl _target;

    LayerMask layerMask;

    HashSet<Collider2D> _monsters;

    public void FindNearMonster()
    {
        for (int i = 0; i < 5; i++)
        {
            Collider2D monster = Physics2D.OverlapCircle(transform.position, _radius);
            _monsters.Add(monster);
        }

        foreach (Collider2D monster in _monsters)
        {
            if (monster == null)
                continue;

            float dist = (_player.position - monster.transform.position).magnitude;
            float minDist = dist;

            if (dist < minDist)
                minDist = dist;

            
        }
    }

}
