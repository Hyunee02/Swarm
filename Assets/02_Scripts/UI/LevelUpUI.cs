using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    [Header("----- Components -----")]
    [SerializeField] TMP_Text _nameText;
    [SerializeField] TMP_Text _infoText;
    [SerializeField] SpriteRenderer _iconImage;

    UpgradeType _type;

    public void ApplyCard()
    {
        switch (_type)
        {
            case UpgradeType.PlayerStat:

                break;

            case UpgradeType.Skill:
                break;

            case UpgradeType.NewSkill:
                break;
        }
    }

    public void ChangeCardInfo(string name, string info, SpriteRenderer image)
    {
        _nameText.text = name;
        _infoText.text = info;
        _iconImage = image;
    }

    void SelectStat()
    {
        
    }
}
