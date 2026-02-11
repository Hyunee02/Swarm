using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    [SerializeField] Transform[] _tiles;
    [SerializeField] PlayerCtrl _player;

    [SerializeField] int _tileSize;
    [SerializeField] float _maxX;
    [SerializeField] float _maxY;

    private void Update()
    {
        MoveMap();
    }

    public void MoveMap()
    {
        Vector3 playerPos = _player.transform.position;

        foreach (Transform tile in _tiles)
        {
            Vector3 tilePos = tile.transform.position;
            Vector3 offset = playerPos - tilePos;
            Vector3 dir = (playerPos - tilePos).normalized;

            if (offset.x > tilePos.x / 2f)
                tilePos.x += dir.x * _tileSize * 3f;

            if (offset.x < -tilePos.x / 2f)
                tilePos.x -= dir.x * _tileSize * 3f;

            if (offset.y > tilePos.y / 2f)
                tilePos.y += dir.y * _tileSize * 3f;

            if (offset.y < -tilePos.y / 2f)
                tilePos.y -= dir.y * _tileSize * 3f;
        }
    }
}
