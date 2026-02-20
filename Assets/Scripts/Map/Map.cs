//using UnityEngine;

//public class Map : MonoBehaviour
//{
//    [SerializeField] Transform[] _tiles;
//    [SerializeField] PlayerCtrl _player;

//    [SerializeField] int _tileSize;

//    private void Update()
//    {
//        MoveMap();
//    }

//    public void MoveMap()
//    {
//        Vector3 playerPos = _player.transform.position;

//        foreach (Transform tile in _tiles)
//        {
//            Vector3 tilePos = tile.position;

//            float offsetX = playerPos.x - tilePos.x;
//            float offsetY = playerPos.y - tilePos.y;

//            if (offsetX > _tileSize)
//                tilePos.x += _tileSize * 3f;
//            else if (offsetX < -_tileSize)
//                tilePos.x -= _tileSize * 3f;

//            if (offsetY > _tileSize)
//                tilePos.y += _tileSize * 3f;
//            else if (offsetY < -_tileSize)
//                tilePos.y -= _tileSize * 3f;

//            tile.position = tilePos;
//        }
//    }
//}
