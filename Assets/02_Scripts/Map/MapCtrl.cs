using UnityEngine;

public class MapCtrl : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _senseDist;
    [SerializeField] float _reposDist;

    private void Update()
    {
        Vector2 playerPos = _player.transform.position;
        Vector2 tilePos = transform.position;

        float distX = playerPos.x - tilePos.x;
        float distY = playerPos.y - tilePos.y;

        if (Mathf.Abs(distX) > _senseDist)
            tilePos += _reposDist * Vector2.right * Mathf.Sign(distX);

        if (Mathf.Abs(distY) > _senseDist)
            tilePos += _reposDist * Vector2.up * Mathf.Sign(distY);

        transform.position = tilePos;
    }
}