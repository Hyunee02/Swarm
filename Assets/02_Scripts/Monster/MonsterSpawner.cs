using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] PlayerCtrl _player;
    [SerializeField] MonsterCtrl[] _monsterPrefab;
    [SerializeField] LevelUpStats _levelUpStats;

    [SerializeField] float _spawnSpan;
    [SerializeField] int _maxSpawn;
    [SerializeField] float _minRadius;
    [SerializeField] float _maxRadius;
    [SerializeField] float _timer;

    Coroutine _spawnMonsterRoutine;

    private void Start()
    {
        _spawnMonsterRoutine = StartCoroutine(SpawnMonsterRoutine());
    }

    private void Update()
    {
        _timer = Time.deltaTime;
    }

    IEnumerator SpawnMonsterRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnSpan);
            //SpawnMonster();
        }
    }

    //void SpawnMonster()
    //{
    //    if (transform.childCount >= _maxSpawn)
    //        return;

    //    MonsterCtrl monster = Instantiate(_monsterPrefab[0], transform);
    //    monster.Initialize(_player, _levelUpStats);
    //    Vector2 pos = GetSpawnPosition();
    //    monster.transform.position = pos;
    //}

    Vector2 GetSpawnPosition()
    {
        Vector2 pos = _player.transform.position;
        float radius = Random.Range(_minRadius, _maxRadius);
        Vector2 dir = Random.insideUnitCircle.normalized;

        pos.x += dir.x * radius;
        pos.y += dir.y * radius;

        return pos;
    }

    void SpawnMonster()
    {
        if (transform.childCount >= _maxSpawn)
            return;

        for (int i = 0; i < _monsterPrefab.Length; i++)
        {
            MonsterCtrl spawnMonster = _monsterPrefab[i];

            if (_timer == spawnMonster.Data.SpawnTime)
            {
                MonsterCtrl monster = Instantiate(_monsterPrefab[0], transform);
                monster.Initialize(_player, _levelUpStats);
                Vector2 pos = GetSpawnPosition();
                monster.transform.position = pos;
            }
            if (_timer == spawnMonster.Data.SpawnDuration)
            {
                spawnMonster = _monsterPrefab[i+1];
            }
        }
}