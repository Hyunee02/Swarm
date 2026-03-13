using System.Collections;
using UnityEngine;

public class DarkBullet : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] MonsterCtrl _monster;
    [SerializeField] Bullet _bulletPrefab;

    [SerializeField] float _radius;
    [SerializeField] float _bulletSpeed;

    Coroutine shootRoutine;

    private void Start()
    {
        shootRoutine = StartCoroutine(ShootRoutine());
    }

    void FindNearMonster()
    {
        Collider2D[] monsters = Physics2D.OverlapCircleAll(transform.position, _radius);

        for (int i = 0; i < monsters.Length; i++)
        {
            float dist = Vector2.Distance(_player.position, monsters[i].transform.position);
            float nearDist = dist;

            if (dist < nearDist)
                nearDist = dist;

            ShootBullet(monsters[i]);
        }
    }

    void ShootBullet(Collider2D monster)
    {
        Bullet bullet = Instantiate(_bulletPrefab, transform);
        Vector2 targetPos = Vector2.Lerp(transform.position, monster.transform.position, _bulletSpeed);
        bullet.transform.Translate(targetPos);

        Vector2 dir = (monster.transform.position - bullet.transform.position).normalized;
        bullet.transform.up = dir;
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            FindNearMonster();
            yield return new WaitForSeconds(_bulletPrefab.Data.CoolTime);
        }
    }
}
