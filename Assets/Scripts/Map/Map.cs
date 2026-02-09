using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] Transform[] Tiles;
    [SerializeField] PlayerCtrl _player;

    public void Initialize(PlayerCtrl player)
    {
        _player = player;
    }


}
