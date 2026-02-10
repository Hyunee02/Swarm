using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("----- Player Stats -----")]
    [SerializeField] float _speed;
    [SerializeField] float _area;
    [SerializeField] float _damage;
    [SerializeField] float _maxHp;
    [SerializeField] float _hp;
    [SerializeField] float _level;

    public float Speed => _speed;
    public float Area => _area;
    public float Damage => _damage;
    public float Hp => _hp;
    public float Level => _level;


    public void Init()
    {
        _hp = _maxHp;
    }
    
    public void GetDamage(float damage)
    {
        _hp -= damage;

        if (_hp < 0)
            _hp = 0;
    }

    public void GetArea(float area)
    {

    }

}
