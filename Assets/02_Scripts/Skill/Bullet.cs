using System.Collections.Generic;
using UnityEngine;

public class Bullet : SkillData
{
    [Header("----- Scripts -----")]
    [SerializeField] PlayerCtrl _player;
    [SerializeField] MonsterSpawner _spawner;
    [SerializeField] SkillData _data;

    List<MonsterData> _monster = new();

    public void FindNearMonster()
    {
        

        foreach (MonsterData monster in _monster)
        {
            
        }         
    }
}
