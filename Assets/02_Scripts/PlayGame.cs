using UnityEngine;

public class PlayGame : MonoBehaviour
{
    [SerializeField] LevelManager _levelMgr;
    [SerializeField] PlayerStats _playerStats;
    [SerializeField] UIManager _uiMgr;
    [SerializeField] CurrentSkills _currentSkills;

    private void Awake()
    {
        _levelMgr.UpExp += _uiMgr.UpdateExpGage;
        _playerStats.ChangeHp += _uiMgr.UpdateHpBar;
        _levelMgr.OnLevelUp += _uiMgr.ActiveLevelUpCanv;
    }

    void Start()
    {
        
    }

    void Update()
    {

    }
}
