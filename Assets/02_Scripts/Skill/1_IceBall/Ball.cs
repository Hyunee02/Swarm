using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] SkillData _data;

    CircleCollider2D _collider;
    SpriteRenderer _renderer;

    [SerializeField] float _timer;
    [SerializeField] float _activeDuration;

    Coroutine _activeRoutine;
    Tween _activeTween;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CircleCollider2D>();

        _timer = _activeDuration;
    }

    private void Start()
    {
        _activeRoutine = StartCoroutine(ActiveBallRoutine());
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Monster"))
        {
            MonsterCtrl monster = coll.GetComponent<MonsterCtrl>();
            monster.TakeDamage(_data.Power);
        }
    }

    IEnumerator ActiveBallRoutine()
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
