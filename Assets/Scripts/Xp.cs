using UnityEngine;
using DG.Tweening;

public class Xp : MonoBehaviour
{
    [SerializeField] PlayerCtrl _player;
    [SerializeField] MonsterCtrl _monster;
    [SerializeField] LevelManager _levelMgr;

    public void XpMove()
    {
        Vector3 playerPos = _player.transform.position;
        Transform xpPos = transform;

        xpPos.DOMove(playerPos, 3f)
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
        }
    }
}
