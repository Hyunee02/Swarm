using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUpUI : MonoBehaviour
{
    public enum UpgradeType
    {
        PlayerStat,
        Skill
    }

    public enum StatType
    {
        Speed,
        Hp,
        Area,
        Power,
    }

    public enum SkillType
    {

    }

    [Header("----- Scripts -----")]
    [SerializeField] LevelManager _levelMgr;
    [SerializeField] CardData[] _cardData;

    [Header("----- Components -----")]
    [SerializeField] TMP_Text _nameText;
    [SerializeField] TMP_Text _infoText;
    [SerializeField] Image _iconImage;

    StatType _stat;

    // 1. 스탯 랜덤 고르기
    // 2. 스킬 랜덤 고르기 (없는 거는 생성되게, 있는 건 강화 선택지)
    // 3. 스탯이랑 스킬 나오는 비율

    public void ShowSelect()
    {
        int select = Random.Range(0, 2);

        switch (select)
        {
            case 0:
                RandomSelectStat();
                break;
        }
    }

    public void RandomSelectStat()
    {
        switch (_stat)
        {
            case StatType.Speed:
                _levelMgr.PickSpeed();
                ChangeUI(_cardData[0]);
                break;

            case StatType.Hp:
                _levelMgr.PickHp();
                ChangeUI(_cardData[1]);
                break;

            case StatType.Area:
                _levelMgr.PickArea();
                ChangeUI(_cardData[2]);
                break;

            case StatType.Power:
                _levelMgr.PickPower();
                ChangeUI(_cardData[3]);
                break;
        }
    }
    
    public void ApplyStat(StatType type, CardData cardData)
    {
        
    }

    public void ChangeUI(CardData cardData)
    {
        _nameText.text = cardData.Name;
        _infoText.text = cardData.Info;
        _iconImage = cardData.Icon;
    }
}
