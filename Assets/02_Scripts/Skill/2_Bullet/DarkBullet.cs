using System.Collections.Generic;
using UnityEngine;

public class DarkBullet : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] MonsterCtrl _target;

    [SerializeField] float _radius;

    HashSet<Collider2D> _monsters;

    public void FindNearMonster()
    {
        Collider2D[] monsters = Physics2D.OverlapCircleAll(transform.position, _radius);
        foreach (Collider2D monster in monsters)
        {
            _monsters.Add(monster);
            float dist = Vector2.Distance(_player.position, monster.transform.position);
            
        }
    }

    void ShootBullet()
    {

    }
}
