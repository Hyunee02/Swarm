using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class IceBall : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] PlayerCtrl _player;
    [SerializeField] Ball _ballPrefab;

    SkillData _data;
    SpriteRenderer _renderer;

    [Header("----- Create -----")]
    [SerializeField] float _radius;

    [Header("----- Active -----")]
    [SerializeField] float _timer;
    [SerializeField] float _activeDuration;

    Coroutine _activeRoutine;
    Tween _activeTween;

    private void Awake()
    {
        _data = GetComponentInChildren<SkillData>();
        _renderer = GetComponent<SpriteRenderer>();

        _data.Init();
        _timer = _activeDuration;
    }

    private void Start()
    {
        if (Input.GetKeyDown("Alpha1"))
        {
            CreateBalls();
            _activeRoutine = StartCoroutine(ActiveBallRoutine());
        }
    }

    void CreateBalls()
    {
        float angle = 360f / _data.Count;

        for (int i = 0; i < _data.Count; i++)
        {
            float xPos = Mathf.Cos(angle) * _radius;
            float yPos = Mathf.Sin(angle) * _radius;

            Ball ball = Instantiate(_ballPrefab, transform);
            ball.transform.Translate(xPos, yPos, 0);

            Vector2 dir = (_player.transform.position - ball.transform.position).normalized;
            ball.transform.up = dir;
        }
    }

    IEnumerator ActiveBallRoutine()
    {
        _activeTween = _renderer.DOFade(1f, 1f)
                       .SetEase(Ease.Linear);

        yield return new WaitForSeconds(_activeDuration);

        _activeTween.Kill();

        _activeTween = _renderer.DOFade(0f, 1f)
                       .SetEase(Ease.Linear);

        yield return new WaitForSeconds(_data.CoolTime);

        _activeTween.Kill();

    }

    //IEnumerator DeActiveRoutine()
    //{
    //    _activeTween.Kill();

    //    if (_activeRoutine != null)
    //    {
    //        StopCoroutine(_activeRoutine);
    //        _activeRoutine = null;
    //    }

    //    _timer -= Time.deltaTime;

    //    if (_timer < 0)
    //    {
    //        _renderer.DOFade(0f, 1f)
    //                 .SetEase(Ease.Linear)
    //                 .OnComplete(() => gameObject.SetActive(false));

    //        _timer = _activeDuration;
    //    }

    //    yield return new WaitForSeconds(_data.CoolTime);

    //    _activeTween.Play();
    //}

}
