using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Ball : Bullet
{
    [SerializeField] float _activeDuration;

    Coroutine _activeRoutine;
    Tween _activeTween;

    protected override void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CircleCollider2D>();
    }

    private void Start()
    {
        _activeRoutine = StartCoroutine(ActiveBallRoutine());
    }

    protected override void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Monster"))
        {
            MonsterCtrl monster = coll.GetComponent<MonsterCtrl>();
            monster.TakeDamage(_data.Power);
        }
    }

    IEnumerator ActiveBallRoutine()
    {
        while (true)
        {
            _activeTween = _renderer.DOFade(1f, 1f)
               .SetEase(Ease.Linear)
               .OnComplete(() => _collider.enabled = true);

            yield return new WaitForSeconds(_activeDuration);
            _activeTween.Kill();

            _activeTween = _renderer.DOFade(0f, 1f)
                           .SetEase(Ease.Linear)
                           .OnComplete(() => _collider.enabled = false);

            yield return new WaitForSeconds(_data.CoolTime);
            _activeTween.Kill();
        }
    }
}
