using UnityEngine;

public class StatCalculator : MonoBehaviour
{
    [Header("----- Components -----")]
    [SerializeField] PlayerStats _stats;
    [SerializeField] LevelManager _levelMgr;

    [Header("----- RunTime -----")]
    [SerializeField] float _speed;
    [SerializeField] float _maxHp;
    [SerializeField] float _area;
    [SerializeField] float _power;

    [Header("----- Multifly -----")]
    [SerializeField] int[] _mul = { 10, 15, 20 };
    int _randMul;

    public float Speed => _speed;
    public float MaxHp => _maxHp;
    public float Area => _area;
    public float Power => _power;

    public void Init()
    {
        _speed = _stats.BaseSpeed;
        _maxHp = _stats.BaseMaxHp;
        _area = _stats.BaseArea;
        _power = _stats.BasePower;
        _stats.Hp = _maxHp;
    }

    public float CalculateStat(float baseStat, float multifly, int level)
    {
        return baseStat * Mathf.Pow(multifly, level - 1);
    }

    public void RandomMultifly()
    {
        int randIndex = Random.Range(0, _mul.Length);
        _randMul = _mul[randIndex];
    }

    public void UpgradeSpeed(int level)
    {
        RandomMultifly();
        _speed = CalculateStat(_stats.BaseSpeed, _randMul, level);
    }

    // maxHp에 따라 현재 hp 비율 맞춰주는 거 필요
    public void UpgradeHp(int level)
    {
        RandomMultifly();
        _maxHp = CalculateStat(_stats.BaseMaxHp, _randMul, level);
    }

    public void UpgradeArea(int level)
    {
        RandomMultifly();
        _area = CalculateStat(_stats.BaseArea, _randMul, level);
    }

    public void UpgradePower(int level)
    {
        RandomMultifly();
        _power = CalculateStat(_stats.BasePower, _randMul, level);
    }
}
