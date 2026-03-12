using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] LevelUpStats _levelUpStats;

    [Header("----- Player Stats -----")]
    [SerializeField] float _baseSpeed;
    [SerializeField] float _baseMaxHp;
    [SerializeField] float _baseArea;
    [SerializeField] float _basePower;

    [Header("----- RunTime -----")]
    [SerializeField] float _speed;
    [SerializeField] float _maxHp;
    [SerializeField] float _area;
    [SerializeField] float _power;
    [SerializeField] float _hp;

    [Header("----- Multifly -----")]
    int[] _mul = { 10, 15, 20 };
    int _randMul;

    public float BaseArea => _baseArea;
    public float Speed => _speed;
    public float Power => _power;
    public float Area => _area;
    public float Hp
    {
        get {  return _hp; }
        set { _hp = value; }
    }

    public event UnityAction<float, float> ChangeHp;

    public void Init()
    {
        _hp = _baseMaxHp;
        _speed = _baseSpeed;
        _maxHp = _baseMaxHp;
        _area = _baseArea;
        _power = _basePower;
    }

    public void Damage(float damage)
    {
        _hp -= damage;
        _hp = Mathf.Clamp(_hp, 0, _baseMaxHp);
        ChangeHp?.Invoke(_hp, _baseMaxHp);
    }

    public void RandomMultifly()
    {
        int randIndex = Random.Range(0, _mul.Length);
        _randMul = _mul[randIndex];
    }

    public float CalculateStat(float baseStat, float multifly, int level)
    {
        return baseStat * Mathf.Pow(multifly, level - 1);
    }

    public void UpgradeSpeed(int level)
    {
        RandomMultifly();
        _speed = CalculateStat(_baseSpeed, _randMul, level);
    }

    // maxHp에 따라 현재 hp 비율 맞춰주는 거 필요
    public void UpgradeHp(int level)
    {
        RandomMultifly();
        _maxHp = CalculateStat(_baseMaxHp, _randMul, level);
    }

    public void UpgradeArea(int level)
    {
        RandomMultifly();
        _area = CalculateStat(_baseArea, _randMul, level);
    }

    public void UpgradePower(int level)
    {
        RandomMultifly();
        _power = CalculateStat(_basePower, _randMul, level);
    }
}
