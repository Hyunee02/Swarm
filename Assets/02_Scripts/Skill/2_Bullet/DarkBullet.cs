using UnityEngine;

public class DarkBullet : MonoBehaviour
{
    [SerializeField] Bullet _bulletPrefab;

    [SerializeField] float _coolTime;

    void ShootingBullet()
    {
        Bullet bullet = Instantiate(_bulletPrefab);

        
    }
}
