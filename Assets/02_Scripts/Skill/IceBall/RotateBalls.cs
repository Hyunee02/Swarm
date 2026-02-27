using UnityEngine;
using DG.Tweening;
using System.Collections;

public class RotateBalls : MonoBehaviour
{
    [Header("----- Data -----")]
    [SerializeField] SkillData _data;

    [Header("----- Components -----")]
    [SerializeField] SpriteRenderer _renderer;

    [SerializeField] float _speed;
    [SerializeField] float _activeDuration;
    [SerializeField] float _rotDuration;

    Coroutine _activeRoutine;


    private void Update()
    {
        ActiveBall();

        if (_activeRoutine == null)
            _activeRoutine = StartCoroutine(DeActiveRoutine());
    }

    void RotateBall()
    {
        transform.DORotate(new Vector3(0, 0, -360), _rotDuration, RotateMode.Fast)
                 .SetLoops(-1, LoopType.Restart)
                 .SetEase(Ease.Linear);
    }

    void ActiveBall()
    {
        _renderer.DOFade(1f, 1f)
         .SetEase(Ease.Linear)
         .OnComplete(() => gameObject.SetActive(true));
    }

    IEnumerator DeActiveRoutine()
    {
        if (_activeRoutine != null)
        {
            StopCoroutine(_activeRoutine);
            _activeRoutine = null;
        }

        float timer = Time.deltaTime;

        if (timer > _activeDuration)
        {
            _renderer.DOFade(0f, 1f)
                     .SetEase(Ease.Linear)
                     .OnComplete(() => gameObject.SetActive(false));

            timer = 0;
        }

        yield return new WaitForSeconds(_data.CoolTime);

        ActiveBall();
    }
}