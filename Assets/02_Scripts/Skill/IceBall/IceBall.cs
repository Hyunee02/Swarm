using System;
using UnityEngine;

public class IceBall : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] SkillData _data;
    [SerializeField] PlayerCtrl _player;

    [SerializeField] Ball _iceBallPrefab;

    [SerializeField] float _angle;
    [SerializeField] float _radius;

    private void Awake()
    {
        _data.Init();
    }

    void Update()
    {
        _angle = 360 / _data.Count;

        float xPos = Mathf.Cos(_angle * Mathf.Deg2Rad) * _radius;
        float yPos = Mathf.Sin(_angle * Mathf.Deg2Rad) * _radius;

        for (int i = 0; i < _data.Count; i++)
        {
            Ball ball = Instantiate(_iceBallPrefab);

            ball.transform.Translate(xPos, yPos, 0);

            Vector2 dir = (_player.transform.position - ball.transform.position).normalized;
            ball.transform.up = dir;
        }
    }
}
