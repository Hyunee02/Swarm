using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

/*
레벨업 UI는 연결해주는 거

랜덤 선택 (각 4종류)
1. 스킬 강화
2. 스탯 강화

1. 스킬 강화를 눌렀을 시
-> 4개 중 하나를 내보내야 하자나
주의점
1. 스킬 레벨 5일 시 선택지 X
2. 획득한 스킬에서만 강화 선택지를 내보내기

2. 스탯 강화를 눌렀을 시
4개 중 랜덤

근데 카드 3개니까
1개는 스킬 강화
1개는 스탯 강화
1개는 새 스킬
카테고리 정해놓고 나오게 할까?

나 mul도 랜덤으로 하고 싶은데 5단위로 10-20정도
*/

public class LevelUpUI : MonoBehaviour
{
    public enum UpgradeType
    {
        PlayerStat,
        Skill,
        NewSkill
    }

    [Header("----- Scripts -----")]
    [SerializeField] LevelManager _levelMgr;
    [SerializeField] SkillData[] _skills;

    [SerializeField] TMP_Text _nameText;
    [SerializeField] TMP_Text _explainText;
    [SerializeField] Image _iconImage;

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
                break;

            case UpgradeType.NewSkill:
                SelectSkill();
                break;
        }
    }

    //public void ChangeCardInfo(string name, string info, SpriteRenderer image)
    //{
    //    _nameText.text = name;
    //    _infoText.text = info;
    //    _iconImage = image;
    //}

    void SelectStat()
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

    void SelectSkill()
    {
        int rand = Random.Range(0, _skills.Length);

        foreach (var skill in _curSkill)
        {
            if (_skills[rand] == skill)
                return;
        }

        SkillData selectSkill = _skills[rand];
        _curSkill.Add(selectSkill);

        ChangeSkillInfo(selectSkill.Name, selectSkill.Explain, selectSkill.IconImage);
    }

    void UpgradeSkill()
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

    void ChangeSkillInfo(string name, string explain, Image icon)
    {
        _nameText.text = name;
        _explainText.text = explain;
        _iconImage = icon;
    }
}
