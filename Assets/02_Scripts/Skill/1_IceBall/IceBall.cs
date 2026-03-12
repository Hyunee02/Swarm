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

    private void Awake()
    {
        _data = _ballPrefab.Data;
        _data.Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            CreateBalls();
    }

    void CreateBalls()
    {
        float angle = 360f / _data.Count;

        for (int i = 0; i < _data.Count; i++)
        {
            Ball ball = Instantiate(_ballPrefab, transform);

            float xPos = Mathf.Cos(i * angle * Mathf.Deg2Rad) * _radius;
            float yPos = Mathf.Sin(i * angle * Mathf.Deg2Rad) * _radius;

            ball.transform.localPosition = new Vector2(xPos, yPos);

            Vector2 dir = (ball.transform.position - _player.transform.position).normalized;
            ball.transform.up = dir;
        }
    }
}
