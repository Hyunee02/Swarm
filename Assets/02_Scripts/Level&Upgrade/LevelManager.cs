using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] StatCalculator _statCal;

    [Header("----- RunTime -----")]
    [SerializeField] int _level;

    float _curXp;
    float _baseXp;
    float _needXp;
    float _mul;

    int _speedLv;
    int _hpLv;
    int _areaLv;
    int _powerLv;

    public int Level => _level;

    public event Action<int> OnLevelUp;

    public void GetXp(float xp)
    {
        _curXp += xp;
    }

    public void LevelUp()
    {
        if (_needXp >= _curXp)
        {
            _level++;
            _curXp -= _needXp;
            _needXp = IncreaseNeedXp(_level);
            OnLevelUp?.Invoke(_level);
        }
    }

    public void PickSpeed()
    {
        _speedLv++;
        _statCal.UpgradeSpeed(_speedLv);
    }

    public void PickHp()
    {
        _hpLv++;
        _statCal.UpgradeHp(_hpLv);
    }

    public void PickArea()
    {
        _areaLv++;
        _statCal.UpgradeArea(_areaLv);
    }

    public void PickPower()
    {
        _powerLv++;
        _statCal.UpgradePower(_powerLv);
    }

    float IncreaseNeedXp(int level)
    {
        return _baseXp * Mathf.Pow(_mul, _level - 1);
    }
}
