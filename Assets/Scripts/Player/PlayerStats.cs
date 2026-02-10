using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("----- Player Stats -----")]
    [SerializeField] float _speed;
    [SerializeField] float _area;
    [SerializeField] float _maxHp;
    [SerializeField] float _hp;
    [SerializeField] float _level;

    public float Speed => _speed;
    public float Area => _area;
    public float Hp => _hp;
    public float Level => _level;

    // 플레이어 스탯 초기화
    public void Init(GameObject area)
    {
        _hp = _maxHp;

        GetArea(area);
    }

    #region 기본 스탯 설정
    public void GetDamage(float damage)
    {
        _hp -= damage;

        if (_hp < 0)
            _hp = 0;
    }

    public void GetArea(GameObject area)
    {
        Vector3 areaScale = new Vector3(_area, _area, 0);
        area.transform.localScale = areaScale;
    }
    #endregion

    #region 스탯 업그레이드

    #endregion

}