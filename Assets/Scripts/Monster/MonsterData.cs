using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Data/Monster")]
public class MonsterData : ScriptableObject
{
    float _speed;
    float _power;
    float _maxHp;
    float _hp;
    float _xp;
    int _level;
    float _spawn;

    public float Hp => _hp;
    public float Power => _power;
    public float Speed => _speed;

    public void Init()
    {
        _hp = _maxHp;
    }

    public void Damage(float damage)
    {
        _hp -= damage;

        if (_hp < 0)
            _hp = 0;
    }
}
