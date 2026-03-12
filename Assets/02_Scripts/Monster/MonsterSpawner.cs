using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] PlayerCtrl _player;
    [SerializeField] MonsterCtrl _monsterPrefab;
    [SerializeField] LevelUpStats _levelUpStats;
    // Å¸ÀÌ¸Ó

    [SerializeField] float _spawnSpan;
    [SerializeField] int _maxSpawn;
    [SerializeField] float _minRadius;
    [SerializeField] float _maxRadius;

    Coroutine _spawnMonsterRoutine;

    private void Start()
    {
        _spawnMonsterRoutine = StartCoroutine(SpawnMonsterRoutine());
    }

    IEnumerator SpawnMonsterRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnSpan);
            SpawnMonster();
        }
    }

    void SpawnMonster()
    {
        if (transform.childCount >= _maxSpawn)
            return;

        MonsterCtrl monster = Instantiate(_monsterPrefab, transform);
        monster.Initialize(_player, _levelUpStats);
        Vector2 pos = GetSpawnPosition();
        monster.transform.position = pos;
    }

    Vector2 GetSpawnPosition()
    {
        Vector2 pos = _player.transform.position;
        float radius = Random.Range(_minRadius, _maxRadius);
        Vector2 dir = Random.insideUnitCircle.normalized;

        pos.x += dir.x * radius;
        pos.y += dir.y * radius;

        return pos;
    }
}