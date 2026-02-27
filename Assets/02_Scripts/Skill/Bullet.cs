using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] PlayerCtrl _player;
    [SerializeField] MonsterSpawner _spawner;
    [SerializeField] SkillData _data;

    [SerializeField] float _radius;

    List<MonsterData> _monster = new();

    private void Awake()
    {
        _data.Init();
    }

    void FindNearMonster()
    {
        Vector2 dir = (_player.transform.position - _)
    }

    void MoveBullet()
    {

    }
}
