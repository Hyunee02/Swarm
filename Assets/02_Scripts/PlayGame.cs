using UnityEngine;

public class PlayGame : MonoBehaviour
{
    [SerializeField] LevelUpStats _levelUpStats;
    [SerializeField] PlayerStats _playerStats;
    [SerializeField] UIManager _uiMgr;
    [SerializeField] LevelUpUI _levelUpUI;

    private void Awake()
    {
        _levelUpStats.UpExp += _uiMgr.UpdateExpGage;
        _playerStats.ChangeHp += _uiMgr.UpdateHpBar;
        _levelUpStats.OnLevelUp += _uiMgr.ActiveLevelUpCanv;
        _levelUpUI.SelectComplete += _uiMgr.DeActiveLevelUpCanv;
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
}
