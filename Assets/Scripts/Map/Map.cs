using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] Transform[] _tiles;
    [SerializeField] PlayerCtrl _player;

    [SerializeField] int _tileSize;

    Vector3 playerPos;

    private void Update()
    {
        MoveMap();
    }

    public void MoveMap()
    {
        playerPos = _player.transform.position;

        foreach (Transform tile in _tiles)
        {
            Vector3 tilePos = tile.position;
            Vector3 offset = playerPos - tilePos;

            if (offset.x > tilePos.x / 2f)
                tilePos.x += Vector3.right.x * _tileSize * 3f;
            else if (offset.x < -tilePos.x / 2f)
                tilePos.x += Vector3.left.x * _tileSize * 3f;

            if (offset.y > tilePos.y / 2f)
                tilePos.y += Vector3.up.y * _tileSize * 3f;
            else if (offset.y < -tilePos.y / 2f)
                tilePos.y += Vector3.down.y * _tileSize * 3f;

            tile.position = tilePos;
        }
    }
}
