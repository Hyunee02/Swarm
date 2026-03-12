using DG.Tweening;
using UnityEngine;

public class RotateBall : MonoBehaviour
{
    [SerializeField] float _rotDuration;
    [SerializeField] float _timer;

    Tween rotTween;

    void Update()
    {
        _timer = _rotDuration;
        RotateBalls();
    }

    void RotateBalls()
    {
        _timer -= Time.deltaTime;

        rotTween = transform.DORotate(new Vector3(0, 0, -360), _rotDuration, RotateMode.Fast)
                    .SetLoops(-1, LoopType.Restart)
                    .SetEase(Ease.Linear);

        if (_timer < 0)
            rotTween.Kill();
    }
}
