using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    [SerializeField] Tilemap[] _tiles;
    [SerializeField] PlayerCtrl _player;

    [SerializeField] float _maxX;
    [SerializeField] float _maxY;

    private void Start()
    {
        
    }

    private void Update()
    {
        MoveMap();
    }

    public void MoveMap()
    {
        Vector2 playerPos = _player.transform.position;



        //Vector2 playerPos = _player.transform.position;
        //Vector2 mapPos = transform.position;

        //mapPos.x = playerPos.x;
        //mapPos.y = playerPos.y;

        //transform.position = mapPos;

        //Vector2 curPlayerPos = playerPos / 10f;

        //_tileSize = 10f;

        //if (playerPos.x > 14 && playerPos.x < -6)
        //{
        //    foreach (var tile in _tiles)
        //    {
        //        tile.transform.Translate(_tileSize);
        //    }
        //}
        
    }


}
