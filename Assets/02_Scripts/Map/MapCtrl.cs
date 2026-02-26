using UnityEngine;

public class MapCtrl : MonoBehaviour
{
    [Header("----- Scripts -----")]
    [SerializeField] PlayerCtrl _player;

    [Header("----- Components -----")]
    [SerializeField] Transform[] _tiles;

    [SerializeField] int _tileSize;

    private void Update()
    {
        MoveTile();
    }

    void MoveTile()
    {
        Vector3 playerPos = _player.transform.position;

        foreach (Transform tile in _tiles)
        {
            Vector3 tilePos = tile.position;

            float xPos = playerPos.x - tilePos.x;
            float yPos = playerPos.y - tilePos.y;

            if (xPos > _tileSize)
                tilePos.x += _tileSize * 3f;
            else if (xPos < -_tileSize)
                tilePos.x -= _tileSize * 3f;

            if (yPos > _tileSize)
                tilePos.y += _tileSize * 3f;
            else if (yPos < -_tileSize)
                tilePos.y -= _tileSize * 3f;

            tile.position = tilePos;
        }
    }
}
