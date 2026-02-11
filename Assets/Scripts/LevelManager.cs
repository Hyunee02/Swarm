using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] PlayerStats _playerStats;
    [SerializeField] MonsterData _monsterData;

    [SerializeField] float _level;
    [SerializeField] float _xp;
    [SerializeField] float _needXp;

    public void LevelUp()
    {
        if (_needXp == _xp)
        {
            _level++;
            _needXp = _xp * Mathf.Pow(1.25f, (_level - 1));
        }
    }
}
