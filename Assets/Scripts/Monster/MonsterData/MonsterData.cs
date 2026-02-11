using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Data/Monster")]
public class MonsterData : ScriptableObject
{
    [SerializeField] float _speed;
    [SerializeField] float _power;
    [SerializeField] float _maxHp;
    [SerializeField] float _hp;
    [SerializeField] float _xp;
    [SerializeField] int _level;
    [SerializeField] float _spawn;

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
