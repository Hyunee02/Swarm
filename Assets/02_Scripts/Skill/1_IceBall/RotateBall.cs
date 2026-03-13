using DG.Tweening;
using UnityEngine;

public class RotateBall : MonoBehaviour
{
    [SerializeField] float _rotSpeed;

    void Update()
    {
        RotateBalls();
    }

    void RotateBalls()
    {
        transform.Rotate(0, 0, _rotSpeed * Time.deltaTime);
    }
}
