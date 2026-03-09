using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    [Header("----- Player Stats -----")]
    [SerializeField] float _baseSpeed;
    [SerializeField] float _baseMaxHp;
    [SerializeField] float _baseArea;
    [SerializeField] float _basePower;

    [Header("----- RunTime -----")]
    [SerializeField] float _hp;

    public event UnityAction<float, float> ChangeHp;

    public float Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }
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
        ChangeHp?.Invoke(_hp, _baseMaxHp);
    }
}
