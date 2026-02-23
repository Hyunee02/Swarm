using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Data/Skill")]
public abstract class SkillData : ScriptableObject
{
    public enum StatType
    {
        Power,
        CoolTime,
        Count,
    }

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

    public float BasePower => _basePower;

    public void Init()
    {
        _level = 1;
        _maxLevel = 5;
        _power = _basePower;
        _coolTime = _baseCoolTime;
        _count = _baseCount;
    }

    public void CalculateStat(StatType type, float multifly, int level)
    {

    }

    public void LevelUpSkill(int level)
    {
        
    }

    // 1. 계수로 넣어줘야하나
    // 2. 각각 다른 선택지를 하나씩 줘야하나....
    // 3. 레벨업 할 때 모든 걸 업글 시켜줘야하나...
}
