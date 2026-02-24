using UnityEngine;

public class IceBall : SkillData
{
    [SerializeField] SkillData _data;
    [SerializeField] PlayerCtrl _player;

    [SerializeField] GameObject _iceBallPrefab;

    [SerializeField] Vector2 _gap;
    [SerializeField] 

    public void StartSkill()
    {
        Vector2 playerPos = _player.transform.position;

        Instantiate(_iceBallPrefab, playerPos + _gap, Quaternion.identity);
    }

    void RotateIceBall()
    {
        
    }
}
