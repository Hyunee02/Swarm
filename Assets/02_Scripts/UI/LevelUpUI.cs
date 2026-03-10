using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelUpUI : MonoBehaviour
{
    public enum UpgradeType
    {
        PlayerStat,
        Skill,
        NewSkill,
        Count
    }

    [Header("----- Scripts -----")]
    [SerializeField] LevelManager _levelMgr;
    [SerializeField] CurrentSkills _currentSkills;
    [SerializeField] LevelUpCard[] _cards;
    [SerializeField] SkillData[] _skills;

    [SerializeField] string[] _stats = { "speed", "hp", "area", "power" };

    List<SkillData> _curSkill;
    
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
    }

    public void SelectUpgradeType()
    {
        for (int i = 0; i < _cards.Length; i++)
        {
            int rand = Random.Range(0, (int)UpgradeType.Count);
            _cards[i] = _cards[rand];


            
        }

    }


    public void SelectStat()
    {
        int rand = Random.Range(0, _stats.Length);

        if (rand == 0)
            _levelMgr.PickSpeed();
        if (rand == 1)
            _levelMgr.PickHp();
        if (rand == 2)
            _levelMgr.PickArea();
        if (rand == 3)
            _levelMgr.PickPower();
    }

    public void SelectSkill()
    {
        int rand = Random.Range(0, _skills.Length);

        foreach (var skill in _curSkill)
        {
            if (_skills[rand] == skill)
                return;
        }

        SkillData selectSkill = _skills[rand];
        _curSkill.Add(selectSkill);
        _currentSkills.ShowCurrentSkills(_curSkill);
    }

    public void UpgradeSkill()
    {
        int rand = Random.Range(0, _curSkill.Count);

        foreach (var skill in _curSkill)
        {
            if (_skills[rand] != skill)
                return;
        }

        SkillData selectSkill = _skills[rand];

        if (selectSkill.Level == selectSkill.MaxLevel)
            return;

        selectSkill.LevelUpSkill();
    }
}
