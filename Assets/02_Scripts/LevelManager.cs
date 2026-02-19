using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float _level;
    [SerializeField] float _selecetLevel;
    [SerializeField] float _curXp;
    [SerializeField] float _needXp;

    public void LevelUp()
    {
        if (_needXp == _curXp)
        {
            _level++;
            _needXp = _curXp * Mathf.Pow(1.25f, (_level - 1));
        }
    }

    public void GetXp(float xp)
    {
        _curXp += xp;
    }

    public void SkillSelect()
    {
        _selecetLevel = _level * Mathf.Pow(3, (_level - 1));
    }
}
