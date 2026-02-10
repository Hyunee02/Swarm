using UnityEngine;
using DG.Tweening;

public class MonsterRenderer : MonoBehaviour
{
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] Animator _anim;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    public void MRMove(Vector2 dir)
    {
        _anim.SetTrigger("IsMove");

        if (dir.x >= 0)
            _renderer.flipX = false;
        else
            _renderer.flipX = true;
    }

    public void MRDamage()
    {
        _renderer.DOColor(Color.red, 1.5f)
                 .SetLoops(2, LoopType.Yoyo)
                 .SetEase(Ease.Linear);
        // 다시 원래 색으로 돌아오기
    }

    public void MRDeath()
    {

    }
}
