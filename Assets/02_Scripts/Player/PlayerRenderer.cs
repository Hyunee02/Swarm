using DG.Tweening;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] Animator _anim;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    public void RMove(Vector2 velocity)
    {
        if (velocity.x > 0)
            _renderer.flipX = false;
        if (velocity.x < 0)
            _renderer.flipX = true;

        _anim.SetFloat("MoveSpeed", velocity.magnitude);
    }

    public void RDamage()
    {
        _renderer.DOColor(Color.red, 0.3f)
         .SetLoops(2, LoopType.Yoyo)
         .SetEase(Ease.Linear)
         .OnComplete(() => _renderer.color = Color.white);
    }

    public void RDead()
    {
        _anim.SetBool("IsDead", true);
    }
}
