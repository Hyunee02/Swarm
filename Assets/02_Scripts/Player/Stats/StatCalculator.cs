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
    [SerializeField] float _mul;

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
    }

    float CalculateStat(float baseStat, float multifly, int level)
    {
        return baseStat * Mathf.Pow(multifly, level - 1);
    }

    public void UpgradeSpeed(int level)
    {
        _speed = CalculateStat(_stats.BaseSpeed, _mul, level);
    }

    public void UpgradeHp(int level)
    {
        _maxHp = CalculateStat(_stats.BaseMaxHp, _mul, level);
    }

    public void UpgradeArea(int level)
    {
        _area = CalculateStat(_stats.BaseArea, _mul, level);
    }

    public void UpgradePower(int level)
    {
        _power = CalculateStat(_stats.BasePower, _mul, level);
    }
}
