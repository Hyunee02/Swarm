using UnityEngine;
using DG.Tweening;

public class Xp : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] PlayerCtrl _player;
    [SerializeField] MonsterCtrl _monster;
    [SerializeField] LevelManager _levelMgr;

    public float xpAmount;

    Tween _moveTween;

    public void Initialize(PlayerCtrl player, MonsterCtrl monster, LevelManager levelMgr)
    {
        _player = player;
        _monster = monster;
        _levelMgr = levelMgr;
    }

    public void XpMove()
    {
        Vector3 playerPos = _player.transform.position;
        Transform xpPos = transform;

        _moveTween = xpPos.DOMove(playerPos, 2f)
                    .SetEase(Ease.InCubic)
                    .SetSpeedBased()
                    .OnComplete(() => Destroy(gameObject));
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Area"))
        {
            XpMove();
        }

        if (coll.CompareTag("Player"))
        {
            _levelMgr.GetXp(_monster.Data.Xp);
            _moveTween.Kill();
        }
    }
}
