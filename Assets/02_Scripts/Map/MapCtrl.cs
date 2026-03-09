using UnityEngine;

public class MapCtrl : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Transform[] _tiles;
    [SerializeField] float _senseDist;
    [SerializeField] float _reposDist;

    private void Update()
    {
        Vector2 playerPos = _player.position;

        for (int i = 0; i < _tiles.Length; i++)
        {
            Transform tile = _tiles[i];
            Vector2 tilePos = tile.position;

            float distX = playerPos.x - tilePos.x;
            float distY = playerPos.y - tilePos.y;

            if (Mathf.Abs(distX) > _senseDist)
                tilePos += _reposDist * Vector2.right * Mathf.Sign(distX);

            if (Mathf.Abs(distY) > _senseDist)
                tilePos += _reposDist * Vector2.up * Mathf.Sign(distY);

            tile.position = tilePos;
        }
    }
}