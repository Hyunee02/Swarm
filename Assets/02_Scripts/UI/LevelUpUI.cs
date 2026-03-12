using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public enum UpgradeType
{
    PlayerStat,
    Skill,
    NewSkill,
    Count
}

public class LevelUpUI : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] LevelUpStats _levelUpStats;
    [SerializeField] CurrentSkills _currentSkills;
    [SerializeField] LevelUpCard[] _cards;
    [SerializeField] SkillData[] _skills;

    [SerializeField] string[] _stats = { "speed", "hp", "area", "power" };

    List<SkillData> _curSkills;
    HashSet<SkillData> _ownedSkills;

    public event UnityAction SelectComplete;
    
    UpgradeType _type;

    public void ApplyCard()
    {
        switch (_type)
        {
            case UpgradeType.PlayerStat:
                SelectStat();
                break;

            case UpgradeType.Skill:
                UpgradeSkill();
                break;

            case UpgradeType.NewSkill:
                SelectSkill();
                break;
        }
        SelectComplete?.Invoke();
    }

    public void SelectUpgradeType()
    {
        for (int i = 0; i < _cards.Length; i++)
        {
            int rand = Random.Range(0, (int)UpgradeType.Count);
            _cards[i].Type = (UpgradeType)rand;
        }
    }

    public void SelectStat()
    {
        int rand = Random.Range(0, _stats.Length);

        if (rand == 0)
            _levelUpStats.PickSpeed();
        if (rand == 1)
            _levelUpStats.PickHp();
        if (rand == 2)
            _levelUpStats.PickArea();
        if (rand == 3)
            _levelUpStats.PickPower();
    }

    public void SelectSkill()
    {
        int rand = Random.Range(0, _skills.Length);
        SkillData selectSkill = _skills[rand];

        if (_ownedSkills.Contains(selectSkill))
            return;
        else
        {
            _ownedSkills.Add(selectSkill);
            _currentSkills.ShowOwnedSkills(_ownedSkills);
        }
    }

    public void UpgradeSkill()
    {
        int rand = Random.Range(0, _ownedSkills.Count);
        SkillData selectSkill = _skills[rand];

        if (selectSkill.Level == selectSkill.MaxLevel)
            return;

        selectSkill.LevelUpSkill();
    }

    // 카드 효과
}
