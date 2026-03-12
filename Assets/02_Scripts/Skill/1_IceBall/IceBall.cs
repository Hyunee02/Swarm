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

    [SerializeField] float _radius;
    [SerializeField] float _rotDuration;

    private void Awake()
    {
        _data = _ballPrefab.Data;
        _data.Init();
    }

    private void Start()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            CreateBalls();

        RotateBall();
    }

    void CreateBalls()
    {
        float angle = 360f / _data.Count;

        for (int i = 0; i < _data.Count; i++)
        {
            float xPos = Mathf.Cos(i * angle * Mathf.Deg2Rad) * _radius;
            float yPos = Mathf.Sin(i * angle * Mathf.Deg2Rad) * _radius;

            Ball ball = Instantiate(_ballPrefab, transform);
            ball.transform.localScale = new Vector2(xPos, yPos);

            Vector2 dir = (_player.transform.position - ball.transform.position).normalized;
            ball.transform.up = dir;
        }
    }

    void RotateBall()
    {
        transform.DORotate(new Vector3(0, 0, -360), _rotDuration, RotateMode.Fast)
                 .SetLoops(-1, LoopType.Restart)
                 .SetEase(Ease.Linear);
    }
}
