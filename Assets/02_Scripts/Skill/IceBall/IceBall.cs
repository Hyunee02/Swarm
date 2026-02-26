using UnityEngine;

public class IceBall : SkillData
{
    [SerializeField] SkillData _data;
    [SerializeField] PlayerCtrl _player;

    [SerializeField] IceBall _iceBallPrefab;

    [SerializeField] float _radius;
    public float pi = Mathf.PI;

    private void Awake()
    {
        _data.Init();
    }

    public void StartSkill()
    {
        Vector2 center = _player.transform.position;

        Instantiate(_iceBallPrefab, playerPos, Quaternion.identity);
    }
}
