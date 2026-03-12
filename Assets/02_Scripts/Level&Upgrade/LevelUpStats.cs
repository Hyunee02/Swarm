using System;
using UnityEngine;
using UnityEngine.Events;

public class LevelUpStats : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] PlayerStats _stats;

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

    public event UnityAction<float, float> UpExp;
    public event UnityAction OnLevelUp;

    public void GetXp(float xp)
    {
        _curXp += xp;
        UpExp?.Invoke(_curXp, _needXp);
    }

    float IncreaseNeedXp(int level)
    {
        return _baseXp * Mathf.Pow(_mul, _level - 1);
    }

    public void LevelUp()
    {
        if (_needXp >= _curXp)
        {
            _level++;
            _curXp -= _needXp;
            _needXp = IncreaseNeedXp(_level);
            OnLevelUp?.Invoke();
        }
    }

    public void PickSpeed()
    {
        if (_speedLv >= 5)
            return;

        _speedLv++;
        _stats.UpgradeSpeed(_speedLv);
    }

    public void PickHp()
    {
        if (_hpLv >= 5)
            return;

        _hpLv++;
        _stats.UpgradeHp(_hpLv);
    }

    public void PickArea()
    {
        if (_areaLv >= 5)
            return;

        _areaLv++;
        _stats.UpgradeArea(_areaLv);
    }

    public void PickPower()
    {
        if (_powerLv >= 5)
            return;

        _powerLv++;
        _stats.UpgradePower(_powerLv);
    }
}
