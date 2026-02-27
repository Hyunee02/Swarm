using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Data/Skill")]
public class SkillData : ScriptableObject
{

    [Header("----- BaseStats -----")]
    [SerializeField] float _basePower;
    [SerializeField] float _baseCoolTime;
    [SerializeField] int _baseCount;
    [SerializeField] int _maxLevel;

    [Header("----- RunTime -----")]
    [SerializeField] int _level;
    [SerializeField] float _power;
    [SerializeField] float _coolTime;
    [SerializeField] float _count;

    public float Power => _power;
    public float CoolTime => _coolTime;
    public float Count => _count;

    public void Init()
    {
        _level = 1;
        _maxLevel = 5;
        _power = _basePower;
        _coolTime = _baseCoolTime;
        _count = _baseCount;
    }
}
