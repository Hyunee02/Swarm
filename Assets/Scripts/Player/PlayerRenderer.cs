using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    [SerializeField] SpriteRenderer _renderer;
    [SerializeField] Animator _anim;

    public void ChangeRenderer(Vector2 dir)
    {
        if (dir.x >= 0)
            _renderer.flipX = false;
        else
            _renderer.flipX = true;

        _anim.SetTrigger("IsMove");
    }
}
