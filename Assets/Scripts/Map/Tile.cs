using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile : MonoBehaviour
{
    [SerializeField] Transform[] _tiles;
    [SerializeField] PlayerCtrl _player;

    [SerializeField] int _tileSize;
    [SerializeField] float _maxX;
    [SerializeField] float _maxY;

    private void Update()
    {
        //MoveMap();
    }

    public void MoveMap()
    {
        Vector3 playerPos = _player.transform.position;

        foreach (Transform tile in _tiles)
        {
            Vector3 tilePos = tile.transform.position;
            Vector3 dir = (playerPos - tilePos).normalized;

            if (playerPos.x > tilePos.x)
            {
                tile.transform.position += dir * _tileSize * 3f;
            }

            //if (playerPos.x < tilePos.x)
            //{
            //    tile.transform.position -= dir * _tileSize * 3f;
            //}

        }
    }
}
