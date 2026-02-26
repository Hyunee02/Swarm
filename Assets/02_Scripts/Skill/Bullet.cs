using System.Collections.Generic;
using UnityEngine;

public class Bullet : SkillData
{
    [Header("----- Scripts -----")]
    [SerializeField] PlayerCtrl _player;
    [SerializeField] MonsterSpawner _spawner;
    [SerializeField] SkillData _data;

    List<MonsterData> _monster = new();

    private void Awake()
    {
        _data.Init();
    }

    public void FindNearMonster()
    {
        Vector3 playerPos = _player.transform.position;
    }
}
