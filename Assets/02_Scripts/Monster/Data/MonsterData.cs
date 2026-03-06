using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Data/Monster")]
public class MonsterData : ScriptableObject
{
    [SerializeField] float _maxHp;
    [SerializeField] float _hp;
    [SerializeField] float _baseSpeed;
    [SerializeField] float _speed;
    [SerializeField] float _power;
    [SerializeField] float _xp;

    public float Hp => _hp;
    public float Speed => _speed;
    public float Power => _power;
    public float Xp => _xp;

    public void Init()
    {
        _hp = _maxHp;
        _speed = _baseSpeed;
    }

    public void Damage(float damage)
    {
        _hp -= damage;
        _hp = Mathf.Clamp(_hp, 0, _maxHp);
    }
}
