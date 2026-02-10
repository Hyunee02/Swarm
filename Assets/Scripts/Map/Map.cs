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
        
    }


}
