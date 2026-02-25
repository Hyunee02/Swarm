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

    public void MRCreate()
    {
        _anim.SetBool("IsDead", false);
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
        _renderer.DOColor(Color.red, 0.3f)
                 .SetLoops(2, LoopType.Yoyo)
                 .SetEase(Ease.Linear)
                 .OnComplete(() => _renderer.color = Color.white);
    }

    public void MRDead()
    {
        _anim.SetBool("IsDead", true);
    }
}
