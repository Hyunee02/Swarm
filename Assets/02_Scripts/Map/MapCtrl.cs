using UnityEngine;

public class MapCtrl : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] Transform[] _tiles;
    [SerializeField] int _tileSize;

    private void Update()
    {
        Vector2 playerPos = _player.position;

        for (int i = 0; i < _tiles.Length; i++)
        {
            Transform tile = _tiles[i];
            Vector2 tilePos = tile.position;

            float distX = tilePos.x - playerPos.x;
            if (Mathf.Abs(distX) > tilePos.x / 2f)
                tilePos += _tileSize * 3f * Vector2.right * Mathf.Sign(distX);

            float distY = tilePos.y - playerPos.y;
            if (Mathf.Abs(distY) > tilePos.y / 2f)
                tilePos += _tileSize * 3f * Vector2.up * Mathf.Sign(distY);

            tile.position = tilePos;
        }
    }
}
