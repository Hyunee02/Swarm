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
    [SerializeField] float _rotDuration;

    private void Update()
    {
        RotateBall();
    }

    void RotateBall()
    {
        transform.DORotate(new Vector3(0, 0, -360), _rotDuration, RotateMode.Fast)
                 .SetLoops(-1, LoopType.Restart)
                 .SetEase(Ease.Linear);
    }
}