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
        _data = GetComponentInChildren<SkillData>();

        _data.Init();
    }

    private void Start()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            CreateBalls();
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
}
