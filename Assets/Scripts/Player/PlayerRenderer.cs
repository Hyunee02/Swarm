using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] Animator _anim;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    #region 플레이어 이동
    public void RMove(Vector2 dir)
    {
        if (dir.x >= 0)
            _renderer.flipX = false;
        else
            _renderer.flipX = true;

        _anim.SetBool("IsMove", true);
    }
    #endregion

    #region 대쉬
    public void RDash(Vector2 dir)
    {
        _anim.SetTrigger("OnDash");
    }

    #endregion
}
