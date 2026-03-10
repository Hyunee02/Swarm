using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

public class IceBall : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] PlayerCtrl _player;
    SkillData _data;
    SpriteRenderer _renderer;

    [SerializeField] Ball _ballPrefab;

    [Header("----- Create -----")]
    [SerializeField] float _angle;
    [SerializeField] float _radius;

    [Header("----- Active -----")]
    [SerializeField] float _timer;
    [SerializeField] float _activeDuration;

    Coroutine _activeRoutine;
    Tween _activeTween;

    private void Awake()
    {
        _data = GetComponentInChildren<SkillData>();

        _data.Init();
        _timer = _activeDuration;
    }

    private void Start()
    {
        CreateBalls();
    }

    private void Update()
    {
        ActiveBall();

        if (_activeRoutine == null)
            _activeRoutine = StartCoroutine(DeActiveRoutine());
    }

    void CreateBalls()
    {
        _angle = (360 / _data.Count) * Mathf.Deg2Rad;

        float xPos = Mathf.Cos(_angle) * _radius;
        float yPos = Mathf.Sin(_angle) * _radius;

        for (int i = 0; i < _data.Count; i++)
        {
            Ball ball = Instantiate(_ballPrefab, transform);

            ball.transform.Translate(xPos, yPos, 0);

            Vector2 dir = (_player.transform.position - ball.transform.position).normalized;
            ball.transform.up = dir;
        }
    }

    void ActiveBall()
    {
        _activeTween = _renderer.DOFade(1f, 1f)
                .SetEase(Ease.Linear)
                .OnComplete(() => gameObject.SetActive(true));
    }

    IEnumerator DeActiveRoutine()
    {
        _activeTween.Kill();

        if (_activeRoutine != null)
        {
            StopCoroutine(_activeRoutine);
            _activeRoutine = null;
        }

        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            _renderer.DOFade(0f, 1f)
                     .SetEase(Ease.Linear)
                     .OnComplete(() => gameObject.SetActive(false));

            _timer = _activeDuration;
        }

        yield return new WaitForSeconds(_data.CoolTime);

        _activeTween.Play();
    }

}
