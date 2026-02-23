using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("----- Player Stats -----")]
    [SerializeField] float _baseSpeed;
    [SerializeField] float _baseMaxHp;
    [SerializeField] float _baseArea;
    [SerializeField] float _basePower;

    [Header("----- RunTime -----")]
    [SerializeField] float _hp;

    public float Hp => _hp;
    public float BaseSpeed => _baseSpeed;
    public float BaseMaxHp => _baseMaxHp;
    public float BaseArea => _baseArea;
    public float BasePower => _basePower;

    public void Init()
    {
        _hp = _baseMaxHp;
    }

    public void Damage(float damage)
    {
        _hp -= damage;
        _hp = Mathf.Clamp(_hp, 0, _baseMaxHp);
    }
}
