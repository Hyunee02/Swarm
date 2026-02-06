using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("----- Player Stats -----")]
    [SerializeField] float _speed;
    [SerializeField] float _area;
    [SerializeField] float _damage;
    [SerializeField] float _hp;

    public float Speed => _speed;
    public float Area => _area;
    public float Damage => _damage;
    public float Hp => _hp;
}
